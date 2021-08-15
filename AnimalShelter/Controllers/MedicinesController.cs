using AnimalShelter_WebAPI.DTOs.VetVisitDetails;
using AnimalShelter_WebAPI.Services.VetVisitsDetails;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Controllers
{
    [Authorize(Roles = "Vet")]
    [Route("api/[controller]")] 
    [ApiController]
    public class MedicinesController : ControllerBase
    {
  
        private readonly IMedicinesService _medicinesDbService;
        public MedicinesController(IMedicinesService medicinesDbService)
        {
          
            _medicinesDbService = medicinesDbService;
        }

        [HttpGet]
        public IActionResult GetMedicines()
        {
            return Ok(_medicinesDbService.GetMedicines());
        }

       
        [HttpPost]
        public IActionResult CreateMedicine([FromBody] CreateMedicineRequest createMedicineRequest)
        {
            _medicinesDbService.CreateMedicine(createMedicineRequest);
            return Ok();

        }

        [HttpDelete("{Id}")]
        public IActionResult RemoveMedicine(int Id)
        {
            _medicinesDbService.RemoveMedicine(Id);
            return Accepted();
        }

    }
}
