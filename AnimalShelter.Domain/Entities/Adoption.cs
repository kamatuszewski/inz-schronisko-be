using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalShelter.Domain.Entities
{
    public partial class Adoption
    {
        public int Id { get; set; }
        public DateTime AdoptionDate { get; set; }
        public string Notes { get; set; }
        public DateTime? ControlDate { get; set; }
        public bool IsItOwnerPickUp { get; set; }
        public int IdAnimal { get; set; }
        public int IdAdopter { get; set; }
        public int IdEmployee { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsActive { get; set; }

        public virtual Adopter IdAdopterNavigation { get; set; }
        public virtual Animal IdAnimalNavigation { get; set; }
        public virtual AdoptionOfficeWorker IdEmployeeNavigation { get; set; }
    }
}
