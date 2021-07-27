using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalShelter.Domain.Entities
{
    public partial class Medicine
    {
        public Medicine()
        {
            PrescribedMedicines = new HashSet<PrescribedMedicine>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<PrescribedMedicine> PrescribedMedicines { get; set; }
    }
}
