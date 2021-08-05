using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Requests
{
    public class CreateAnimalRequest
    {
        public int ShelterNumber { get; set; }
        public int ChipNumber { get; set; }
        public int BirthYear { get; set; }
        public string Sex { get; set; }
        public DateTime FoundDate { get; set; }
        public string FoundPlace { get; set; }

        public string Species { get; set; }
        public string Status { get; set; }
    }
}
