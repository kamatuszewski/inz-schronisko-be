
using AnimalShelter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Controllers
{
   // [Authorize]
    [Route("api/[controller]")] //rownoznaczne z ("api/animals")
    [ApiController]
    public class AnimalsController : ControllerBase
    {

        public IConfiguration _configuration;
        private readonly IAnimalsDbService _animalsDbService;
        public AnimalsController(IAnimalsDbService animalsDbService, IConfiguration configuration)
        {
            _configuration = configuration;
            _animalsDbService = animalsDbService;
        }

        [HttpGet]
        public IActionResult GetAnimals()
        {
            return Ok(_animalsDbService.GetAnimals());
        }

        [HttpGet("{shelterNumber}")]
        public IActionResult GetAnimal(int shelterNumber)
        {
            var animal = _animalsDbService.GetAnimal(shelterNumber);
            if (animal is null)
            {
                return NotFound();
            }
            else 
                return Ok(animal);
        }
    }
}
