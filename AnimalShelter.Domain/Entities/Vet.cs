using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalShelter.Domain.Entities
{
    public partial class Vet
    {
        public Vet()
        {
            VetSpecialties = new HashSet<VetSpecialty>();
            VetVisits = new HashSet<VetVisit>();
        }

        public int Id { get; set; }
        public string Pwznumber { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsActive { get; set; }

        public virtual Employee IdNavigation { get; set; }
        public virtual ICollection<VetSpecialty> VetSpecialties { get; set; }
        public virtual ICollection<VetVisit> VetVisits { get; set; }
    }
}
