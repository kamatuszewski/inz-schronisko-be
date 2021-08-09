﻿
using AnimalShelter.Services;
using AnimalShelter_WebAPI.DTOs.Requests;
using AnimalShelter_WebAPI.Services.Animals;
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

        private readonly IAnimalsService _animalsDbService;
        public AnimalsController(IAnimalsService animalsDbService)
        {
            _animalsDbService = animalsDbService;
        }

        [HttpGet]
        public IActionResult GetAnimals()
        {
            return Ok(_animalsDbService.GetAnimals());
        }

        [HttpGet("{Id}")]
        public IActionResult GetAnimal(int Id)
        {
            var animal = _animalsDbService.GetAnimal(Id);
            if (animal is null)
                return NotFound();
            else 
                return Ok(animal);
        }

        [HttpPost]
        public IActionResult CreateAnimal([FromHeader] CreateAnimalRequest createAnimalRequest)
        {
            _animalsDbService.CreateAnimal(createAnimalRequest);
            return Ok();

        }

        [HttpDelete("{Id}")]
        public IActionResult RemoveAnimal(int Id)
        {
            _animalsDbService.RemoveAnimal(Id);
            return Accepted();
        }

        [Route("Statuses")]
        [HttpGet]
        public IActionResult GestStatuses()
        {
            return Ok(_animalsDbService.GetStatuses());
        }

        [Route("Species")]
        [HttpGet]
        public IActionResult GetSpecies()
        {
            return Ok(_animalsDbService.GetSpecies());
        }
    }
}
