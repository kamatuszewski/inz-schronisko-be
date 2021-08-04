using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace AnimalShelter.Models 
{
    public class VetVisit:BaseEntity
    {
        public int IdVet { get; set; }
        public int IdAnimal { get; set; }
        public DateTime VisitDateTime { get; set; }
        public string Description { get; set; }


        public virtual Vet Vet { get; set; }
        public virtual Animal Animal { get; set; }
        public virtual ICollection<PrescribedMedicine> PrescribedMedicines { get; set; }
        public virtual ICollection<PerformedTreatment> PerformedTreatments { get; set; }

    }
}
