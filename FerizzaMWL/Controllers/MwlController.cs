using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FerizzaMWL.Attributes;
using FerizzaMWL.Data;
using FerizzaMWL.Models;
using Microsoft.AspNetCore.Http;

namespace FerizzaMWL.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController, Authorize]

    public class MwlController : ControllerBase
    {
        private readonly MWLDataContext _context;
        private readonly SQLDataContext _sqlContext;

        public MwlController(MWLDataContext context, SQLDataContext sqlContext)
        {
            _context = context;
            _sqlContext = sqlContext;
        }

        [HttpGet("alldata")]
        public async Task<ActionResult<IEnumerable<MwlSCP>>> GetAllData()
        {
            var lst = await _sqlContext.MwlSCP.ToListAsync();
            return lst;
        }

        [HttpGet("currentdata")]
        public async Task<ActionResult<IEnumerable<MwlSCP>>> GetCurrentData()
        {
            var lst = await _sqlContext.MwlSCP.Where(s => s.TAG_SCHEDULED_PROCEDURE_STEP_START_DATE.Value.Year.Equals(DateTime.Now.Year)
                      && s.TAG_SCHEDULED_PROCEDURE_STEP_START_DATE.Value.Month.Equals(DateTime.Now.Month)
                      && s.TAG_SCHEDULED_PROCEDURE_STEP_START_DATE.Value.Date.Equals(DateTime.Now.Date)).ToListAsync();
            return lst;
        }

        [HttpPost]
        public async Task<IActionResult> PostMWLAsync([FromForm] MwlSCP mwl)
        {
            if (!(mwl.TAG_PATIENT_SEX == "M" || mwl.TAG_PATIENT_SEX == "F"))
            {
                return NotFound("Patient sex (TAG_PATIENT_SEX) is only M or F!");
            }

            if (!(mwl.TAG_REQUESTED_PROCEDURE_PRIORITY == "LOW" || mwl.TAG_REQUESTED_PROCEDURE_PRIORITY == "MEDIUM" || mwl.TAG_REQUESTED_PROCEDURE_PRIORITY == "HIGH"))
            {
                return NotFound("Procedure Priority (TAG_REQUESTED_PROCEDURE_PRIORITY) is only LOW or MEDIUM or HIGH!");
            }

            var validPIC = await _sqlContext.Users.FirstOrDefaultAsync(s => s.UserName.ToLower().Trim() == mwl.TAG_USERNAME_IN_CHARGE.ToLower().Trim());
            if (validPIC == null)
            {
                return NotFound("Radiologist Username (TAG_USERNAME_IN_CHARGE) is not in the list! Please check the Radiologist List.");
            }

            var modality = await _sqlContext.ModalityList.FirstOrDefaultAsync(s => s.Code.ToLower().Trim() == mwl.TAG_MODALITY.ToLower().Trim());
            if (modality == null)
            {
                return NotFound("Modality (TAG_MODALITY) is not in the list! Please check the Modality List.");
            }

            var aetitle = await _context.MWLClient.FirstOrDefaultAsync(s => s.AeTitle.ToLower().Trim() == mwl.TAG_SCHEDULED_STATION_AE_TITLE.ToLower().Trim());
            if (aetitle == null)
            {
                return NotFound("AE Title (TAG_SCHEDULED_STATION_AE_TITLE) is not in the list! Please check the AE Title List.");
            }

            var validStudy = await _sqlContext.MwlSCP.FirstOrDefaultAsync(s => s.TAG_STUDY_INSTANCE_UID == mwl.TAG_STUDY_INSTANCE_UID);
            if (validStudy != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                            "Duplicate STUDY INSTANCE UID!");
            }

            try
            {
                MwlSCPTbl tbl = new MwlSCPTbl();
                tbl.TAG_ACCESSION_NUMBER = mwl.TAG_ACCESSION_NUMBER;
                tbl.TAG_ADMISSION_ID = mwl.TAG_ADMISSION_ID;
                tbl.TAG_INSTITUTION_NAME = mwl.TAG_INSTITUTION_NAME;
                tbl.TAG_MODALITY = mwl.TAG_MODALITY;
                tbl.TAG_PATIENT_BIRTH_DATE = mwl.TAG_PATIENT_BIRTH_DATE;
                tbl.TAG_PATIENT_ID = mwl.TAG_PATIENT_ID;
                tbl.TAG_PATIENT_NAME = mwl.TAG_PATIENT_NAME;
                tbl.TAG_PATIENT_SEX = mwl.TAG_PATIENT_SEX;
                tbl.TAG_PATIENT_WEIGHT = mwl.TAG_PATIENT_WEIGHT;
                tbl.TAG_REASON_FOR_THE_REQUESTED_PROCEDURE = mwl.TAG_REASON_FOR_THE_REQUESTED_PROCEDURE;
                //tbl.TAG_REFERRING_PHYSICIAN_NAME = string.IsNullOrEmpty(mwl.TAG_REFERRING_PHYSICIAN_NAME) ? $"| {mwl.TAG_USERNAME_IN_CHARGE} | {mwl.TAG_REQUESTED_PROCEDURE_PRIORITY}" : $"{mwl.TAG_REFERRING_PHYSICIAN_NAME} | {mwl.TAG_USERNAME_IN_CHARGE} | {mwl.TAG_REQUESTED_PROCEDURE_PRIORITY}";
                tbl.TAG_REFERRING_PHYSICIAN_NAME = mwl.TAG_REFERRING_PHYSICIAN_NAME;
                tbl.TAG_REQUESTED_PROCEDURE_DESCRIPTION = mwl.TAG_REQUESTED_PROCEDURE_DESCRIPTION;
                tbl.TAG_REQUESTED_PROCEDURE_ID = mwl.TAG_REQUESTED_PROCEDURE_ID;
                tbl.TAG_REQUESTED_PROCEDURE_PRIORITY = mwl.TAG_REQUESTED_PROCEDURE_PRIORITY;
                tbl.TAG_REQUESTING_PHYSICIAN = mwl.TAG_REQUESTING_PHYSICIAN;
                tbl.TAG_SCHEDULED_PERFORMING_PHYSICIAN_NAME = mwl.TAG_SCHEDULED_PERFORMING_PHYSICIAN_NAME;
                tbl.TAG_SCHEDULED_PROCEDURE_STEP_DESCRIPTION = mwl.TAG_SCHEDULED_PROCEDURE_STEP_DESCRIPTION;
                tbl.TAG_SCHEDULED_PROCEDURE_STEP_ID = mwl.TAG_SCHEDULED_PROCEDURE_STEP_ID;
                tbl.TAG_SCHEDULED_PROCEDURE_STEP_LOCATION = mwl.TAG_SCHEDULED_PROCEDURE_STEP_LOCATION;
                tbl.TAG_SCHEDULED_PROCEDURE_STEP_START_DATE = mwl.TAG_SCHEDULED_PROCEDURE_STEP_START_DATE;
                tbl.TAG_SCHEDULED_PROCEDURE_STEP_START_TIME = mwl.TAG_SCHEDULED_PROCEDURE_STEP_START_TIME;
                tbl.TAG_SCHEDULED_STATION_AE_TITLE = mwl.TAG_SCHEDULED_STATION_AE_TITLE;
                tbl.TAG_STUDY_INSTANCE_UID = mwl.TAG_STUDY_INSTANCE_UID;

                _context.MwlSCPTbl.Add(tbl);
                await _context.SaveChangesAsync();

                _sqlContext.MwlSCP.Add(mwl);
                await _sqlContext.SaveChangesAsync();

                //return Accepted();

                return CreatedAtAction(nameof(GetAllData),
                new { id = mwl.Item_ID }, mwl);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        ex.Message);
            }
        }

        [HttpDelete("/studyinstanceuid/{studyinstanceuid}")]
        //[HttpDelete]
        public async Task<ActionResult<MwlSCP>> DeleteMWLAsync(string studyinstanceuid)
        {
            try
            {
                var result = await _sqlContext.MwlSCP.FirstOrDefaultAsync(s => s.TAG_STUDY_INSTANCE_UID == studyinstanceuid);

                if (result == null)
                {
                    return NotFound($"Tag Study Instance UI = {studyinstanceuid} not found");
                }

                var result2 = await _context.MwlSCPTbl.FirstOrDefaultAsync(s => s.TAG_STUDY_INSTANCE_UID == studyinstanceuid);
                if (result2 != null)
                {
                    _context.MwlSCPTbl.Remove(result2);
                    await _context.SaveChangesAsync();
                }

                _sqlContext.MwlSCP.Remove(result);
                await _sqlContext.SaveChangesAsync();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
