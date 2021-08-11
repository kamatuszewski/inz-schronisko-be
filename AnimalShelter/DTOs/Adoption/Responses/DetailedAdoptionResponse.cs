using AnimalShelter_WebAPI.DTOs.Animal.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Adoption.Responses
{
    public class DetailedAdoptionResponse
    {
        public int Id { get; set; }
        public string Notes { get; set; }
        public DateTime AdoptionDate { get; set; }
        public bool IsOwnerPickup { get; set;}

        [JsonPropertyName("animal")]
        public GeneralAnimalResponse GeneralAnimalResponse { get; set; }

        [JsonPropertyName("employee")]
        public EmployeeResponse EmployeeResponse { get; set; }
        [JsonPropertyName("adopter")]
        public AdopterResponse AdopterResponse { get; set; }


    }
}
