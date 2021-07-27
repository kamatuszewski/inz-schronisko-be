using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalShelter.Domain.Entities
{
    public partial class AdoptionOfficeWorker
    {
        public AdoptionOfficeWorker()
        {
            Adoptions = new HashSet<Adoption>();
        }

        public int IdEmployee { get; set; }
        public int IdSpecies { get; set; }
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsActive { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual Species IdSpeciesNavigation { get; set; }
        public virtual ICollection<Adoption> Adoptions { get; set; }
    }
}
