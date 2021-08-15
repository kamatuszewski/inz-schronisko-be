using AnimalShelter_WebAPI.DTOs.VetVisitDetails;
using AnimalShelter_WebAPI.DTOs.VetVisitDetails.VetVisits.Requests;
using AnimalShelter_WebAPI.Services.Animals;
using AnimalShelter_WebAPI.Services.VetVisitsDetails;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VetVisitsController : ControllerBase
    {

        public IConfiguration _configuration;
        private readonly IVetVisitsService _vetVisitsDbService;
        public VetVisitsController(IVetVisitsService vetVisitsDbService)
        {

            _vetVisitsDbService = vetVisitsDbService;
        }

        [HttpGet("{id}")]
        public ActionResult GetVetVisit([FromRoute] int id)
        {
            var vetvisit = _vetVisitsDbService.GetVetVisit(id);
            return Ok(vetvisit);

        }

        [Authorize(Roles = "Vet")]
        [HttpPost]
        public ActionResult CreateVetVisit([FromBody] CreateVetVisitRequest createVetVisitRequest)
        {
          var vetVisit = _vetVisitsDbService.CreateVetVisit(createVetVisitRequest);
            return Ok(vetVisit.Id);

        }

        [Authorize(Roles = "Vet")]
        [HttpPut("{id}")]
        public IActionResult UpdateVetVisit([FromRoute] int id, [FromBody] UpdateVetVisitRequest updateVetVisitRequest)
        {

            _vetVisitsDbService.UpdateVetVisit(id, updateVetVisitRequest);
            return Ok();

        }

        /*
        [HttpPost("{id})")]
        public ActionResult AddDetailsToVetVisit([FromRoute] int id, [FromBody] AddDetailsToVetVisitRequest addDetailsToVetVisitRequest)
        {
            _vetVisitsDbService.AddDetailsToVetVisit(id, addDetailsToVetVisitRequest);
            return Ok();

        }
        */

        [Authorize(Roles = "Vet")]
        [HttpDelete("{Id}")]
        public IActionResult RemoveVetVisit(int Id)
        {
            _vetVisitsDbService.RemoveVetVisit(Id);
            return Accepted();
        }

        [Authorize(Roles = "Vet")]
        [Route("{visitId}/medicines/{medicineId}")]
        [HttpDelete]
        public ActionResult RemoveMedicineFromVisit([FromRoute] int visitId, [FromRoute] int medicineId)
        {
            _vetVisitsDbService.RemoveMedicineFromVisit(visitId, medicineId);
            return Accepted();
        }

        [Authorize(Roles = "Vet")]
        [Route("{visitId}/treatments/{treatmentId}")]
        [HttpDelete]
        public ActionResult RemoveTreatmentFromVisit([FromRoute] int visitId, [FromRoute] int treatmentId)
        {
            _vetVisitsDbService.RemoveTreatmentFromVisit(visitId, treatmentId);
            return Accepted();
        }

    }
}
