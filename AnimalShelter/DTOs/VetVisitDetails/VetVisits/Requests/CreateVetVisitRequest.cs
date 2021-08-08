using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.VetVisitDetails
{
    public class CreateVetVisitRequest
    {
        [FromHeader]
        [Required]
        public int VetId { get; set; }
        [Required]
        [FromHeader]
        public int AnimalId { get; set; }
        [Required]
        [FromHeader]
        public DateTime VisitDate { get; set; }
        [Required]
        [FromHeader]
        public string Description { get; set; }
    }
}
