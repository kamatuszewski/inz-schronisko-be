 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.DTOs.Responses
{
    public class AnimalResponse
    {
        public int ShelterNumber { get; set; }
        public int ChipNumber { get; set; }
        public int BirthYear { get; set; }
        public string Sex { get; set; }
        public DateTime FoundDate { get; set; }
        public string FoundPlace { get; set; }
        public DateTime? DeathDate { get; set; }

       // public int IdStatus { get; set; }
        public string Status { get; set; } //do przerobienia z IdStatus

        // public int IdSpecies { get; set; }
        public string Species { get; set; } //do przerobienia z IdSpecies
    }
}
