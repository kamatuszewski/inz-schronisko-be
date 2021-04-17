using AnimalShelter.Models;
using AnimalShelter.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleDbService _context;
        public PeopleController(IPeopleDbService context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetPeople()
        {
         //code to be added
            return Ok(_context.GetPeople());
        }
    }
}
