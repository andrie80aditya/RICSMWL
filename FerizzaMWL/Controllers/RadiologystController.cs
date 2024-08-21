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

    public class RadiologystController : ControllerBase
    {
        private readonly SQLDataContext _context;
        public RadiologystController(SQLDataContext context)
        {
            _context = context;
        }

        [HttpGet("alldata")]
        public async Task<ActionResult<IEnumerable<Radiologyst>>> GetAllData()
        {
            var lst = await _context.Users.Where(s => s.UserType == "Radiology").ToListAsync();
            var lstRad = (from a in lst
                          select new Radiologyst
                          {
                              UserName = a.UserName,
                              RadiologystName = a.FriendlyName
                          }
                         ).ToList();

            return lstRad;
        }
    }
}
