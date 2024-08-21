using FerizzaMWL.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FerizzaMWL.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MiscController : ControllerBase
    {
        private readonly SQLDataContext _context;
        public MiscController(SQLDataContext context)
        {
            _context = context;
        }

        [HttpGet("getconnectiontime")]
        public int GetConnectionTime()
        {
            int[] numbers = new[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            // Create a Random object
            Random rand = new Random();
            int i = rand.Next(numbers.Length);
            int shuffled = numbers[i];
            return shuffled;
        }

        [HttpGet("passstatus/{studyinstanceuid}/{pscode}")]
        public async Task<bool> GetPassStatusAsync(string studyinstanceuid, string pscode)
        {
            string formatPass = string.Empty;

            var lst = await _context.Study.FirstOrDefaultAsync(s => s.StudyInstanceUID == studyinstanceuid);
            if (lst != null)
            {
                formatPass = string.Format("{0:HHmmss}", lst.StudyDate);
            }

            bool pass = false;
            if (formatPass == pscode)
            {
                pass = true;
            }

            return pass;
        }
    }
}
