using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }
        private readonly ILogger<ValuesController> _logger;

        [HttpGet]
        public  IActionResult GetValues()
        {
            var Values =  _context.Values.ToList();
            return Ok(Values);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public   IActionResult GetValue(int id)
        {
            var value =  _context.Values.FirstOrDefault(x => x.ID == id);
            return Ok(value);
        }

    }
}
