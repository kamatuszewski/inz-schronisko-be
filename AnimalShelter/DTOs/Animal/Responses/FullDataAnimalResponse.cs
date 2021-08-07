using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.Adoption.Responses;
using AnimalShelter_WebAPI.DTOs.Responses.AnimalResponses;
using AnimalShelter_WebAPI.DTOs.VetVisit.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Responses
{
    public class FullDataAnimalResponse
    {
        public DetailedAnimalResponse DetailedAnimalResponse { get; set; }
   
        public virtual ICollection<GeneralVetVisitResponse> VetVisits { get; set; }
        public virtual ICollection<AdoptionResponse> Adoptions { get; set; }


    }
}
