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
    public class CreateVetVisitRequest
    {
       
        [Required]
        public int VetId { get; set; }
        [Required]
        public int AnimalId { get; set; }
        [Required]
        public DateTime VisitDate { get; set; }
        [Required]
        public string Description { get; set; }

    //    [JsonPropertyName("medicines")]
    //    public IEnumerable<PrescribeMedicineRequest> PrescribedMedicines { get; set; }
    //    [JsonPropertyName("treatments")]
     //   public IEnumerable<int> PerformedTreatmentIds { get; set; }
    }
}
