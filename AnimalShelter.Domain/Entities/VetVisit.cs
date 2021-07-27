using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalShelter.Domain.Entities
{
    public partial class VetVisit
    {
        public VetVisit()
        {
            PerformedTreatments = new HashSet<PerformedTreatment>();
            PrescribedMedicines = new HashSet<PrescribedMedicine>();
        }

        public int Id { get; set; }
        public int IdVet { get; set; }
        public int IdAnimal { get; set; }
        public DateTime VisitDateTime { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsActive { get; set; }

        public virtual Animal IdAnimalNavigation { get; set; }
        public virtual Vet IdVetNavigation { get; set; }
        public virtual ICollection<PerformedTreatment> PerformedTreatments { get; set; }
        public virtual ICollection<PrescribedMedicine> PrescribedMedicines { get; set; }
    }
}
