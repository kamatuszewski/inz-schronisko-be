using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalShelter.Domain.Entities
{
    public partial class PrescribedMedicine
    {
        public int Id { get; set; }
        public int IdVisit { get; set; }
        public int Amount { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsActive { get; set; }

        public virtual Medicine IdNavigation { get; set; }
        public virtual VetVisit IdVisitNavigation { get; set; }
    }
}
