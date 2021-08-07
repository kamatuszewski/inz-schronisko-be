using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class GrantedRole
    {
    
        public int PersonId { get; set; }
        public int RoleId { get; set; }

        public virtual Person Person { get; set; }
        public virtual Role Role { get; set; }
    }
}

