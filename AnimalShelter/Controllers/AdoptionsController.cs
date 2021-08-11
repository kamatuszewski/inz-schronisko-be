using AnimalShelter_WebAPI.DTOs.Animal.Requests;
using AnimalShelter_WebAPI.DTOs.Requests;
using AnimalShelter_WebAPI.Services.Adoptions;
using AnimalShelter_WebAPI.Services.Animals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdoptionsController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IAdoptionsService _adoptionsService;
        public AdoptionsController(IAdoptionsService adoptionsService, IConfiguration configuration)
        {
            _configuration = configuration;
            _adoptionsService = adoptionsService;
        }


        [HttpGet]
        public IActionResult GetAdoptions()
        {
            return Ok(_adoptionsService.GetAdoptions());

        }

        //do konkretnej adopcji dostajemy sie poprzez sciezke zwierzecia
        /*
        [HttpGet("{id}")]
        public IActionResult GetAdoption(int id)
        {
            var adoption = _adoptionsService.GetAdoption(id);
            if (adoption is null)
            {
                return NotFound();
            }
            else
                return Ok(adoption);
        }
        */
    }
}
