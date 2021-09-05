using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Person.Vet.Requests
{
    public class AddSpecialtiesToVetRequest
    {
        [Required]
        [JsonPropertyName("id")]
        public int SpecialtyId { get; set; }
        [Required]
        public DateTime ObtainingDate { get; set; }
    }
}
