using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Domain.Models
{
    public class Director:BaseEntity
    {
        public virtual Person Person { get; set; }
    }
}
