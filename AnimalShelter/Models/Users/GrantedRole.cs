using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class GrantedRole:BaseEntity
    {
    
        public int IdPerson { get; set; }
        public int IdRole { get; set; }

        public virtual Person Person { get; set; }    
        public virtual Role Role { get; set; }    
    }
}

