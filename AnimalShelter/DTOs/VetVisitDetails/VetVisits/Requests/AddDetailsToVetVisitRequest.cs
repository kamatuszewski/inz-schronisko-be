using AnimalShelter.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.VetVisitDetails
{
    public class AddDetailsToVetVisitRequest
    {
      

        [JsonPropertyName("medicines")]
        public IEnumerable<PrescribeMedicineRequest> PrescribedMedicines { get; set; }
        [JsonPropertyName("treatments")]
        public IEnumerable<AddPerformedTreatmentRequest> PerformedTreatments { get; set; }
    }
}
