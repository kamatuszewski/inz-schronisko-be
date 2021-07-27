using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalShelter.Domain.Entities
{
    public partial class VetSpecialty
    {
        public int IdVet { get; set; }
        public int IdSpecialty { get; set; }
        public DateTime ObtainingDate { get; set; }
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsActive { get; set; }

        public virtual Specialty IdSpecialtyNavigation { get; set; }
        public virtual Vet IdVetNavigation { get; set; }
    }
}
