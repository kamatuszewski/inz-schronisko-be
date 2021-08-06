﻿
using AnimalShelter.Services;
using AnimalShelter_WebAPI.DTOs.Requests;
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
        private readonly IAnimalsService _animalsDbService;
        public AnimalsController(IAnimalsService animalsDbService, IConfiguration configuration)
        {
            _configuration = configuration;
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
        public IActionResult RemoveAnimal(int id)
        {
            var isDeleted = _animalsDbService.RemoveAnimal(id);
            if (isDeleted)
                return Ok();
            else
                return NotFound();
        }
    }
}
