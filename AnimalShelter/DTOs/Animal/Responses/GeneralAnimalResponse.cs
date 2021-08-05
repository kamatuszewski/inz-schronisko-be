 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.DTOs.Responses
{
    public class GeneralAnimalResponse
    {
        public int Id { get; set; }
        public int ChipNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
        public DateTime FoundDate { get; set; }
        public string FoundPlace { get; set; }
        public DateTime? DeathDate { get; set; }

  
        public string Status { get; set; } 

        public string Species { get; set; } 
    }
}
