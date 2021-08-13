using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.VetVisitDetails.VetVisits.Requests
{
    public class UpdateVetVisitRequest
    {
        [Required]
        public string Description { get; set; }
    }
}
