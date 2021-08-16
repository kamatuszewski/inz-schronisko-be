using AnimalShelter.Services;
using AnimalShelter_WebAPI.DTOs.Animal.Requests;
using AnimalShelter_WebAPI.DTOs.Requests;
using AnimalShelter_WebAPI.Services.Animals;
using AnimalShelter_WebAPI.Services.Persons.Employees;
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
    public class EmployeesController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IEmployeesService _employeesDbService;
        public EmployeesController(IEmployeesService employeesDbService, IConfiguration configuration)
        {
            _configuration = configuration;
            _employeesDbService = employeesDbService;
        }

        [Authorize(Roles = "Director, Admin")]
        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(_employeesDbService.GetEmplyees());

        }

        [Authorize(Roles = "Director, Admin")]
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var volunteer = _employeesDbService.GetEmplyee(id);
            if (volunteer is null)
            {
                return NotFound();
            }
            else
                return Ok(volunteer);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult EditEmployee([FromRoute] int id, [FromBody] EditEmployeeRequest editEmployeeRequest)
        {

            _employeesDbService.EditEmployee(id, editEmployeeRequest);
            return Ok();

        }
    }
}
