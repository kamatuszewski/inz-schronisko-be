using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace AnimalShelter.Models
{
    public class Adopter:BaseEntity
    {
        public string Address { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<Adoption> Adoptions { get; set; }
    }
}
