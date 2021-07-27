using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalShelter.Domain.Entities
{
    public partial class Specialty
    {
        public Specialty()
        {
            VetSpecialties = new HashSet<VetSpecialty>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int MinSalary { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<VetSpecialty> VetSpecialties { get; set; }
    }
}
