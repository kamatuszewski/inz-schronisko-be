using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class Animal:BaseEntity
    {
        public int ShelterNumber { get; set; }
        public int ChipNumber { get; set; }
        public int BirthYear { get; set; }
        public string Sex { get; set; }
        public DateTime FoundDate { get; set; }
        public string FoundPlace { get; set; }
        public DateTime? DeathDate { get; set; }

        public int IdStatus { get; set; }
        public int IdSpecies { get; set; }

        public virtual Species Species { get; set; }
        public virtual Status Status { get; set; }

        public virtual ICollection<VetVisit> VetVisits { get; set; }
        public virtual ICollection<Adoption> Adoptions { get; set; }
    }
}
