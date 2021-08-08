using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.VetVisitDetails
{
    public class CreateTreatmentRequest
    {
        [FromHeader]
        public string Name { get; set; }
    }
}
