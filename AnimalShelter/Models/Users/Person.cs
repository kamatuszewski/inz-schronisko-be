using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class Person:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PESEL { get; set; }
        public string Sex { get; set; }
        public string ContactInfo { get; set; }


        public virtual ICollection<GrantedRole> GrantedRoles { get; set; }
        public virtual ICollection<Volunteer> Volunteers { get; set; }
        public virtual ICollection<Adopter> Adopters { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<Admin> Admins { get; set; }  //to be removed
        public virtual Director Director { get; set; }  //to be removed






    }
}
