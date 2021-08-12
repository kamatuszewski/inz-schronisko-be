using AnimalShelter_WebAPI.DTOs.VetVisitDetails;
using AnimalShelter_WebAPI.Services.Animals;
using AnimalShelter_WebAPI.Services.VetVisitsDetails;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Controllers
{
    [Route("api/animals/{animalId}/vetvisit")]
    [ApiController]
    public class VetVisitsController : ControllerBase
    {

        public IConfiguration _configuration;
        private readonly IVetVisitsService _vetVisitsDbService;
        public VetVisitsController(IVetVisitsService vetVisitsDbService)
        {

            _vetVisitsDbService = vetVisitsDbService;
        }

        [HttpPost]
        public ActionResult CreateVetVisit([FromRoute] int animalId, [FromBody] CreateVetVisitRequest createVetVisitRequest)
        {
            var newVetVisit = _vetVisitsDbService.CreateVetVisit(createVetVisitRequest);
            return Created($"api/{animalId}/vetvisits/{newVetVisit.Id}", null);

        }

        [HttpGet("{visitId}")]
        public ActionResult GetVetVisit([FromRoute] int animalId, [FromRoute] int visitId)
        {
            var vetvisit = _vetVisitsDbService.GetVetVisit(animalId, visitId);
            if (vetvisit is null)
                return NotFound();
            else
                return Ok(vetvisit);

        }
    }
}
