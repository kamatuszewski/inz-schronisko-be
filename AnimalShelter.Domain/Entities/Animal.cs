using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalShelter.Domain.Entities
{
    public partial class Animal
    {
        public Animal()
        {
            Adoptions = new HashSet<Adoption>();
            VetVisits = new HashSet<VetVisit>();
        }

        public int Id { get; set; }
        public int ShelterNumber { get; set; }
        public int ChipNumber { get; set; }
        public int BirthYear { get; set; }
        public string Sex { get; set; }
        public DateTime FoundDate { get; set; }
        public string FoundPlace { get; set; }
        public DateTime? DeathDate { get; set; }
        public int IdStatus { get; set; }
        public int IdSpecies { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsActive { get; set; }

        public virtual Species IdSpeciesNavigation { get; set; }
        public virtual Status IdStatusNavigation { get; set; }
        public virtual ICollection<Adoption> Adoptions { get; set; }
        public virtual ICollection<VetVisit> VetVisits { get; set; }
    }
}
