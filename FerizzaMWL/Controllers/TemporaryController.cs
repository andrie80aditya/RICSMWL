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

    public class TemporaryController : ControllerBase
    {
        private readonly MWLDataContext _context;
        public TemporaryController(MWLDataContext context)
        {
            _context = context;
        }

        [HttpGet("alldata")]
        public async Task<ActionResult<IEnumerable<MwlSCPTbl>>> GetAllData()
        {
            var lst = await _context.MwlSCPTbl.ToListAsync();
            return lst;
        }

        [HttpPost("truncate")]
        public async Task<IActionResult> TruncateAsync()
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync("DELETE FROM MwlSCPTbl");
                return Content("Temporary table has been truncated");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
