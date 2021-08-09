using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class Adoption:BaseEntity
    {
        public DateTime AdoptionDate { get; set; }
        public string Notes { get; set; }
      
        public Boolean IsItOwnerPickUp { get; set; }


        public int AnimalId { get; set; }
        public int AdopterId { get; set; }
        public int EmployeeId { get; set; }


        public virtual Animal Animal { get; set; }
        public virtual Person Adopter { get; set; }
        public virtual Employee Employee { get; set; }

        //  public virtual AdoptionOfficeWorker AdoptionOfficeWorker { get; set; }
    }
}
