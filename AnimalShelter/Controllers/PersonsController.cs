using AnimalShelter.DTOs;
using AnimalShelter.Models;
using AnimalShelter.Services;
using AnimalShelter_WebAPI.DTOs.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

    //  [Authorize]
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


        [HttpGet]
        public IActionResult GetPersons()
        {
              return Ok(_personsDbService.GetPersons());
         
        }

        [HttpGet("{id}")]
        public IActionResult GetPerson(int id)
        {
            var person = _personsDbService.GetPerson(id);
            if (person is null)
            {
                return NotFound();
            }
            else
                return Ok(person);
        }

        
        [HttpPost("register")]
        public IActionResult CreatePerson([FromBody] RegisterPersonRequest createPersonRequest)
        {
            _personsDbService.RegisterPerson(createPersonRequest);
            return Ok();

        }

        [Route("adopters")]
        [HttpPost]
        public IActionResult CreateAdopter([FromBody] CreateAdopterRequest createAdopterRequest)
        {
            _personsDbService.CreateAdopter(createAdopterRequest);
            return Ok();

        }



       /* [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {

         //   Student s = _studentDbService.CheckPass(request.Login, request.Haslo);

            *//*
            if (s == null)
            {
                return NotFound("Zly login lub haslo");
            }
            *//*

            //nie kumaaaam, czemu to jest na sztywno, skad mma wiedziec ile rol etc.
            var userclaim = new[]
                {
                new Claim(ClaimTypes.Name, "mj"),
                new Claim(ClaimTypes.Role, "user1"),
                new Claim(ClaimTypes.Role, "admin"),
                };



            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken
            (
                issuer: "http://localhost:5001",
                audience: "http://localhost:5001",
                claims: userclaim,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            var refreshToken = Guid.NewGuid();
            //  s.refToken = refreshToken.ToString();
          //  _studentDbService.setToken(s, refreshToken);

            return Ok(token);
        }
    }
}
