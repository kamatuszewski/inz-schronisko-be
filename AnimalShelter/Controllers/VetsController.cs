using AnimalShelter_WebAPI.DTOs.Person.Vet.Requests;
using AnimalShelter_WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Controllers
{
    [Route("api/persons/[controller]")]
    [ApiController]
    public class VetsController : ControllerBase
    {
        private readonly IVetsService _vetsDbService;
        public VetsController(IVetsService vetsDbService)
        {
            _vetsDbService = vetsDbService;
        }

        [HttpGet]
        public IActionResult GetVets()
        {
            return Ok(_vetsDbService.GetVets());
        }

        [HttpGet("{Id}")]
        public IActionResult GetVet(int Id)
        {
            var vet = _vetsDbService.GetVet(Id);
            if (vet is null)
                return NotFound();
            else
                return Ok(vet);
        }

        [Route("{vetId}/specialty")]
        [HttpPost]
        public ActionResult AddSpecialtyToVet([FromRoute] int vetId, [FromBody]AddSpecialtyToVetRequest addSpecialtyToVetRequest)
        {
            _vetsDbService.AddSpecialtyToVet(vetId, addSpecialtyToVetRequest);
            return Ok();
        }

        [Route("{vetId}/specialty")]
        [HttpDelete]
        public ActionResult RemoveSpecialtyFromVet([FromRoute] int vetId, [FromBody] RemoveSpecialtyFromVetRequest removeSpecialtyFromVetRequest)
        {
            _vetsDbService.RemoveSpecialtyFromVet(vetId, removeSpecialtyFromVetRequest);
            return Accepted();
        }



        [Route("Specialties")]
        [HttpGet]
        public IActionResult GetSpecialties()
        {
            return Ok(_vetsDbService.GetSpecialties());
        }

        [Route("Specialties")]
        [HttpPost]
        public IActionResult CreateSpecialty([FromBody] CreateSpecialtyRequest createSpecialtyRequest)
        {
            _vetsDbService.CreateSpecialty(createSpecialtyRequest);
            return Ok();

        }

        [HttpDelete("Specialties/{Id}")]
        public IActionResult RemoveSpecialty(int Id)
        {
            _vetsDbService.RemoveSpecialty(Id);
            return Accepted();
        }


    }
}
