using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.VetVisitDetails
{
    public class CreateMedicineRequest
    {
        [FromHeader]
        [Required]
        public string Name { get; set; }
    }
}
