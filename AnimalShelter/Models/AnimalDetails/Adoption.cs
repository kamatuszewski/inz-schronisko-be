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
        public DateTime? ControlDate { get; set; }
        public Boolean IsItOwnerPickUp { get; set; }


        public int IdAnimal { get; set; }
        public int IdAdopter { get; set; }
        public int IdEmployee { get; set; }


        public virtual Animal Animal { get; set; }
        public virtual Adopter Adopter { get; set; }
        public virtual AdoptionOfficeWorker AdoptionOfficeWorker { get; set; }
    }
}
