﻿using AnimalShelter.DTOs;
using AnimalShelter.Models;
using AnimalShelter.Services;
using AnimalShelter_WebAPI.DTOs.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Controllers
{

 //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IPersonsService _personsDbService;
        public PersonsController(IPersonsService personsDbService, IConfiguration configuration)
        {
            _configuration = configuration;
            _personsDbService = personsDbService;
        }

    //    [Authorize(Roles = "Admin, Employee, Vet")]
        [HttpGet]
        public IActionResult GetPersons([FromQuery] GetPersonsRequest getPersonsRequest)
        {
              return Ok(_personsDbService.GetPersons( getPersonsRequest));
         
        }

  //      [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult GetPerson(int id)
        {
            var person = _personsDbService.GetPerson(id);
            return Ok(person);
        }

        [Authorize(Roles = "Admin, Employee")]
        [HttpPost("register")]
        public IActionResult CreatePerson([FromBody] RegisterPersonRequest createPersonRequest)
        {
            var personId = _personsDbService.RegisterPerson(createPersonRequest);
            return Ok(personId);

        }

    
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var token = _personsDbService.GenerateJwt(request);

            return Ok(token);
        }

        [Route("roles")]
        [HttpGet]
        public IActionResult GetRoles()
        {
            return Ok(_personsDbService.GetRoles());
        }

    
        [Route("adopters")]
        [HttpPost]
        public IActionResult CreateAdopter([FromBody] CreateAdopterRequest createAdopterRequest)
        {
            _personsDbService.CreateAdopter(createAdopterRequest);
            return Ok();

        }

   //     [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult EditPerson([FromRoute] int id, [FromBody] EditPersonRequest editPersonRequest)
        {

            _personsDbService.EditPerson(id, editPersonRequest);
            return Ok();

        }

    }
}
