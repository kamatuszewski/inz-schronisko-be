 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.DTOs.Responses
{
    public class GeneralAnimalResponse
    {
        public int Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
        public string Name { get; set; }

  
        public string Status { get; set; } 
        public string Species { get; set; } 
    }
}
