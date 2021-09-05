using AnimalShelter.Models;
using AnimalShelter.Services;
using AnimalShelter_WebAPI.DTOs.Animal.Requests;
using AnimalShelter_WebAPI.DTOs.Requests;
using AnimalShelter_WebAPI.Services.Animals;
using AnimalShelter_WebAPI.Services.Persons.Volunteers;
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
    [Authorize]
    [Route("api/persons/[controller]")]
    [ApiController]
    public class VolunteersController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IVolunteersService _volunteersDbService;
        public VolunteersController(IVolunteersService volunteersDbService, IConfiguration configuration)
        {
            _configuration = configuration;
            _volunteersDbService = volunteersDbService;
        }

        [Authorize(Roles = "Admin, Director")]
        [HttpGet]
        public IActionResult GetVolunteers([FromQuery] GetVolunteersRequest getVolunteersRequest)
        {
            return Ok(_volunteersDbService.GetVolunteers(getVolunteersRequest));

        }

        [Authorize(Roles = "Admin, Director")]
        [HttpGet("{id}")]
        public IActionResult GetVolunteer(int id)
        {
            var volunteer = _volunteersDbService.GetVolunteer(id);
            if (volunteer is null)
            {
                return NotFound();
            }
            else
                return Ok(volunteer);
        }
    }
}
