using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalShelter.Domain.Entities
{
    public partial class Employee
    {
        public int Id { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? QuitDate { get; set; }
        public int Salary { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsActive { get; set; }

        public virtual Person IdNavigation { get; set; }
        public virtual AdoptionOfficeWorker AdoptionOfficeWorker { get; set; }
        public virtual Vet Vet { get; set; }
    }
}
