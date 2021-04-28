using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class Role
    {
        public int IdRole { get; set; }
        public string Name { get; set; }


        public virtual ICollection<GrantedRole> GrantedRoles { get; set; }
    }
}
