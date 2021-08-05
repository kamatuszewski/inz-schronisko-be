using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Responses.AnimalResponses
{
    public class AnimalsFullData
    {
        public int Id { get; set; }
        public int ChipNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
        public DateTime FoundDate { get; set; }
        public string FoundPlace { get; set; }
        public DateTime? DeathDate { get; set; }

        public int StatusId { get; set; }
        public int SpeciesId { get; set; }
    }
}
