using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.Responses.AnimalResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Responses
{
    public class DetailedAnimalResponse
    {
        public AnimalsFullData data { get; set; }
   
        public virtual ICollection<VetVisit> VetVisits { get; set; }
        public virtual ICollection<Adoption> Adoptions { get; set; }


    }
}
