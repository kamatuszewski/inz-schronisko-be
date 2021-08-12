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

        [HttpPost]
        public ActionResult CreateVetVisit([FromBody] CreateVetVisitRequest createVetVisitRequest)
        {
           _vetVisitsDbService.CreateVetVisit(createVetVisitRequest);
            return Ok();

        }

        [HttpPost("{visitId})")]
        public ActionResult AddDetailsToVetVisit([FromRoute] int visitId, [FromBody] AddDetailsToVetVisitRequest addDetailsToVetVisitRequest)
        {
            _vetVisitsDbService.AddDetailsToVetVisit(visitId, addDetailsToVetVisitRequest);
            return Ok();

        }


        [HttpGet("{id}")]
        public ActionResult GetVetVisit([FromRoute] int id)
        {
            var vetvisit = _vetVisitsDbService.GetVetVisit(id);
            return Ok(vetvisit);

        }
    }
}
