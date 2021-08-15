using AnimalShelter.Services;
using AnimalShelter_WebAPI.DTOs.VetVisitDetails;
using AnimalShelter_WebAPI.Services.VetVisitsDetails;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Controllers
{
    [Authorize(Roles = "Vet")]
    [Route("api/[controller]")] 
    [ApiController]
    public class TreatmentsController : ControllerBase
    {
        
        private readonly ITreatmentsService _treatmentsDbService;
        public TreatmentsController(ITreatmentsService treatmentsDbService)
        {
          
            _treatmentsDbService = treatmentsDbService;
        }

        [HttpGet]
        public IActionResult GetTreatments()
        {
            return Ok(_treatmentsDbService.GetTreatments());
        }


        [HttpPost]
        public IActionResult CreateTreatment([FromBody] CreateTreatmentRequest createTreatmentRequest)
        {
            _treatmentsDbService.CreateTreatment(createTreatmentRequest);
            return Ok();

        }

        [HttpDelete("{Id}")]
        public IActionResult RemoveTreatment(int Id)
        {
            _treatmentsDbService.RemoveTreatment(Id);
            return Accepted();
        }

    }
}
