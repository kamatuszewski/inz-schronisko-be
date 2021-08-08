using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.Adoption.Responses;
using AnimalShelter_WebAPI.DTOs.VetVisit.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Animal.Responses
{
    public class FullDataAnimalResponse
    {
        [JsonPropertyName("data")]
        public DetailedAnimalResponse DetailedAnimalResponse { get; set; }
        [JsonPropertyName("vetVisits")]
        public virtual ICollection<GeneralVetVisitResponse> VetVisitResponses { get; set; }
        [JsonPropertyName("adoptions")]
        public virtual ICollection<AdoptionResponse> AdoptionResponses { get; set; }


    }
}
