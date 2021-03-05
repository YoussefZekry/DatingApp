using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DatingApp.API.Data;

namespace DatingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpGet("{id}")]
        public   IActionResult GetValue(int id)
        {
            var value =  _context.Values.FirstOrDefault(x => x.ID == id);
            return Ok(value);
        }

    }
}
