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

    public class AETitleController : Controller
    {
        private readonly MWLDataContext _context;
        public AETitleController(MWLDataContext context)
        {
            _context = context;
        }

        [HttpGet("alldata")]
        public async Task<ActionResult<IEnumerable<MWLClient>>> GetAllData()
        {
            var lst = await _context.MWLClient.ToListAsync();
            return lst;
        }
    }
}
