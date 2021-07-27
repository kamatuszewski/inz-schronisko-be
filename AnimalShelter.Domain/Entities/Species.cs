using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalShelter.Domain.Entities
{
    public partial class Species
    {
        public Species()
        {
            AdoptionOfficeWorkers = new HashSet<AdoptionOfficeWorker>();
            Animals = new HashSet<Animal>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<AdoptionOfficeWorker> AdoptionOfficeWorkers { get; set; }
        public virtual ICollection<Animal> Animals { get; set; }
    }
}
