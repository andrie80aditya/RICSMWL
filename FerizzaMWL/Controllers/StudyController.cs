using FerizzaMWL.Data;
using FerizzaMWL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerizzaMWL.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController, Authorize]
    
    public class StudyController : ControllerBase
    {
        private readonly SQLDataContext _context;
        public StudyController(SQLDataContext context)
        {
            _context = context;
        }

        [HttpGet("currentdata")]
        public async Task<ActionResult<IEnumerable<StudyViewModel>>> GetCurrentData()
        {
            string urlimage = $"https://pacs.rsham.co.id/patient/samples/externalcontroller/viewer.html?study=";
            string urlexp = $"https://pacs.rsham.co.id/ris/Expertise/PrintPreview?study=";

            var lst = await (from a in _context.Study
                             where a.StudyDate.Value.Year.Equals(DateTime.Now.Year) && a.StudyDate.Value.Month.Equals(DateTime.Now.Month) && a.StudyDate.Value.Date.Equals(DateTime.Now.Date)
                             join tbl1 in _context.Patient on a.PatientID equals tbl1.PatientID into ps1
                             from b in ps1.DefaultIfEmpty()
                             select new StudyViewModel
                             {
                                 StudyUID = a.StudyInstanceUID,
                                 StudyDate = a.StudyDate,
                                 StudyDescription = a.StudyDescription,
                                 AccessionNo = a.AccessionNumber,
                                 PatienId = a.PatientID,
                                 PatientName = b == null ? string.Empty : $"{b.FamilyName} {b.GivenName}",
                                 PatientAge = a.PatientAge,
                                 ExpertiseType = a.ExpertiseApproveDate != null ? "Done" : a.ExpertiseDate != null && a.ExpertiseApproveDate == null ? "Need Approval" : "Not Started",
                                 ExpertiseDate = a.ExpertiseApproveDate,
                                 RadiologyDr = a.ExpertiseBy,
                                 ImageUrl = $"{urlimage}{a.StudyInstanceUID}",
                                 ExpertiseUrl = a.ExpertiseApproveDate != null ? $"{urlexp}{a.StudyInstanceUID}&user=PATIENT" : string.Empty,
                                 ExpertiseHtml = a.ExpertiseApproveDate != null ? a.Expertise : string.Empty
                             }).ToListAsync();

            return lst;
        }

        [HttpGet("databyaccession/{accessionno}")]
        public async Task<ActionResult<IEnumerable<StudyViewModel>>> GetDataByAccession(string accessionno)
        {
            string urlimage = $"https://pacs.rsham.co.id/patient/samples/externalcontroller/viewer.html?study=";
            string urlexp = $"https://pacs.rsham.co.id/ris/Expertise/PrintPreview?study=";

            var lst = await (from a in _context.Study
                             where a.AccessionNumber.ToLower().Trim() == accessionno.ToLower().Trim()
                             join tbl1 in _context.Patient on a.PatientID equals tbl1.PatientID into ps1
                             from b in ps1.DefaultIfEmpty()
                             select new StudyViewModel
                             {
                                 StudyUID = a.StudyInstanceUID,
                                 StudyDate = a.StudyDate,
                                 StudyDescription = a.StudyDescription,
                                 AccessionNo = a.AccessionNumber,
                                 PatienId = a.PatientID,
                                 PatientName = b == null ? string.Empty : $"{b.FamilyName} {b.GivenName}",
                                 PatientAge = a.PatientAge,
                                 ExpertiseType = a.ExpertiseApproveDate != null ? "Done" : a.ExpertiseDate != null && a.ExpertiseApproveDate == null ? "Need Approval" : "Not Started",
                                 ExpertiseDate = a.ExpertiseApproveDate,
                                 RadiologyDr = a.ExpertiseBy,
                                 ImageUrl = $"{urlimage}{a.StudyInstanceUID}",
                                 ExpertiseUrl = a.ExpertiseApproveDate != null ? $"{urlexp}{a.StudyInstanceUID}&user=PATIENT" : string.Empty,
                                 ExpertiseHtml = a.ExpertiseApproveDate != null ? a.Expertise : string.Empty
                             }).ToListAsync();

            return lst;
        }

        [HttpGet("databypatientid/{patientid}")]
        public async Task<ActionResult<IEnumerable<StudyViewModel>>> GetDataByPatientID(string patientid)
        {
            string urlimage = $"https://pacs.rsham.co.id/patient/samples/externalcontroller/viewer.html?study=";
            string urlexp = $"https://pacs.rsham.co.id/ris/Expertise/PrintPreview?study=";

            var lst = await (from a in _context.Study
                             where a.PatientID.ToLower().Trim() == patientid.ToLower().Trim()
                             join tbl1 in _context.Patient on a.PatientID equals tbl1.PatientID into ps1
                             from b in ps1.DefaultIfEmpty()
                             select new StudyViewModel
                             {
                                 StudyUID = a.StudyInstanceUID,
                                 StudyDate = a.StudyDate,
                                 StudyDescription = a.StudyDescription,
                                 AccessionNo = a.AccessionNumber,
                                 PatienId = a.PatientID,
                                 PatientName = b == null ? string.Empty : $"{b.FamilyName} {b.GivenName}",
                                 PatientAge = a.PatientAge,
                                 ExpertiseType = a.ExpertiseApproveDate != null ? "Done" : a.ExpertiseDate != null && a.ExpertiseApproveDate == null ? "Need Approval" : "Not Started",
                                 ExpertiseDate = a.ExpertiseApproveDate,
                                 RadiologyDr = a.ExpertiseBy,
                                 ImageUrl = $"{urlimage}{a.StudyInstanceUID}",
                                 ExpertiseUrl = a.ExpertiseApproveDate != null ? $"{urlexp}{a.StudyInstanceUID}&user=PATIENT" : string.Empty,
                                 ExpertiseHtml = a.ExpertiseApproveDate != null ? a.Expertise : string.Empty
                             }).ToListAsync();

            return lst;
        }

        [HttpGet("databystudyinstanceuid/{studyinstanceuid}")]
        public async Task<ActionResult<IEnumerable<StudyViewModel>>> GetDataByStudyInstanceUID(string studyinstanceuid)
        {
            string urlimage = $"https://pacs.rsham.co.id/patient/samples/externalcontroller/viewer.html?study=";
            string urlexp = $"https://pacs.rsham.co.id/ris/Expertise/PrintPreview?study=";

            var lst = await (from a in _context.Study
                             where a.StudyInstanceUID.ToLower().Trim() == studyinstanceuid.ToLower().Trim()
                             join tbl1 in _context.Patient on a.PatientID equals tbl1.PatientID into ps1
                             from b in ps1.DefaultIfEmpty()
                             select new StudyViewModel
                             {
                                 StudyUID = a.StudyInstanceUID,
                                 StudyDate = a.StudyDate,
                                 StudyDescription = a.StudyDescription,
                                 AccessionNo = a.AccessionNumber,
                                 PatienId = a.PatientID,
                                 PatientName = b == null ? string.Empty : $"{b.FamilyName} {b.GivenName}",
                                 PatientAge = a.PatientAge,
                                 ExpertiseType = a.ExpertiseApproveDate != null ? "Done" : a.ExpertiseDate != null && a.ExpertiseApproveDate == null ? "Need Approval" : "Not Started",
                                 ExpertiseDate = a.ExpertiseApproveDate,
                                 RadiologyDr = a.ExpertiseBy,
                                 ImageUrl = $"{urlimage}{a.StudyInstanceUID}",
                                 ExpertiseUrl = a.ExpertiseApproveDate != null ? $"{urlexp}{a.StudyInstanceUID}&user=PATIENT" : string.Empty,
                                 ExpertiseHtml = a.ExpertiseApproveDate != null ? a.Expertise : string.Empty
                             }).ToListAsync();

            return lst;
        }
    }
}
