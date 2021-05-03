using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Domain.Models
{
    public class Admin
    {
        public int IdAdmin { get; set; }


        public virtual Person Person { get; set; }
    }
}
