using AnimalShelter_WebAPI.DTOs.Person.Vet.Requests;
using AnimalShelter_WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Controllers
{
  //  [Authorize]
    [Route("api/persons/[controller]")]
    [ApiController]
    public class VetsController : ControllerBase
    {
        private readonly IVetsService _vetsDbService;
        public VetsController(IVetsService vetsDbService)
        {
            _vetsDbService = vetsDbService;
        }

        [Authorize(Roles = "Admin, Director, Vet")]
        [HttpGet]
        public IActionResult GetVets()
        {
            return Ok(_vetsDbService.GetVets());
        }

        [Authorize(Roles = "Admin, Director")]
        [HttpGet("{Id}")]
        public IActionResult GetVet(int Id)
        {
            var vet = _vetsDbService.GetVet(Id);
                return Ok(vet);
        }

        [Authorize(Roles = "Admin")]
        [Route("{vetId}/specialty")]
        [HttpPost]
        public ActionResult AddSpecialtyToVet([FromRoute] int vetId, [FromBody] IEnumerable<AddSpecialtiesToVetRequest> addSpecialtyToVetRequest)
        {
            _vetsDbService.AddSpecialtiesToVet(vetId, addSpecialtyToVetRequest);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [Route("{vetId}/{specialtyId}")]
        [HttpDelete]
        public ActionResult RemoveSpecialtyFromVet([FromRoute] int vetId, [FromRoute] int specialtyId)
        {
            _vetsDbService.RemoveSpecialtyFromVet(vetId, specialtyId);
            return Accepted();
        }


        //specialties controllers

       
        [Route("Specialties")]
        [HttpGet]
        public IActionResult GetSpecialties()
        {
            return Ok(_vetsDbService.GetSpecialties());
        }

        [Authorize(Roles = "Admin")]
        [Route("Specialties")]
        [HttpPost]
        public IActionResult CreateSpecialty([FromBody] CreateSpecialtyRequest createSpecialtyRequest)
        {
            _vetsDbService.CreateSpecialty(createSpecialtyRequest);
            return Ok();

        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("Specialties/{Id}")]
        public IActionResult RemoveSpecialty(int Id)
        {
            _vetsDbService.RemoveSpecialty(Id);
            return Accepted();
        }


    }
}
