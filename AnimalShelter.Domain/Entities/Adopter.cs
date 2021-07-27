using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalShelter.Domain.Entities
{
    public partial class Adopter
    {
        public Adopter()
        {
            Adoptions = new HashSet<Adoption>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsActive { get; set; }

        public virtual Person IdNavigation { get; set; }
        public virtual ICollection<Adoption> Adoptions { get; set; }
    }
}
