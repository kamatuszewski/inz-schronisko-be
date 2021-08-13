﻿using AnimalShelter_WebAPI.DTOs.VetVisitDetails;
using AnimalShelter_WebAPI.DTOs.VetVisitDetails.VetVisits.Requests;
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

        [HttpGet("{id}")]
        public ActionResult GetVetVisit([FromRoute] int id)
        {
            var vetvisit = _vetVisitsDbService.GetVetVisit(id);
            return Ok(vetvisit);

        }

        [HttpPost]
        public ActionResult CreateVetVisit([FromBody] CreateVetVisitRequest createVetVisitRequest)
        {
           _vetVisitsDbService.CreateVetVisit(createVetVisitRequest);
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdateVetVisit([FromRoute] int id, [FromBody] UpdateVetVisitRequest updateVetVisitRequest)
        {

            _vetVisitsDbService.UpdateVetVisit(id, updateVetVisitRequest);
            return Ok();

        }


        [HttpPost("{id})")]
        public ActionResult AddDetailsToVetVisit([FromRoute] int id, [FromBody] AddDetailsToVetVisitRequest addDetailsToVetVisitRequest)
        {
            _vetVisitsDbService.AddDetailsToVetVisit(id, addDetailsToVetVisitRequest);
            return Ok();

        }

        [Route("{visitId}/medicines/{medicineId}")]
        [HttpDelete]
        public ActionResult RemoveMedicineFromVisit([FromRoute] int visitId, [FromRoute] int medicineId)
        {
            _vetVisitsDbService.RemoveMedicineFromVisit(visitId, medicineId);
            return Accepted();
        }

        [Route("{visitId}/treatments/{treatmentId}")]
        [HttpDelete]
        public ActionResult RemoveTreatmentFromVisit([FromRoute] int visitId, [FromRoute] int treatmentId)
        {
            _vetVisitsDbService.RemoveTreatmentFromVisit(visitId, treatmentId);
            return Accepted();
        }

    }
}
