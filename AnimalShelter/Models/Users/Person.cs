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
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public virtual Volunteer Volunteer { get; set; }
        public virtual Employee Employee { get; set; }


        public virtual ICollection<GrantedRole> GrantedRoles { get; set; }
     //   public virtual ICollection<Volunteer> Volunteer { get; set; }
        public virtual ICollection<Adoption> Adoptions { get; set; }
       // public virtual ICollection<Adopter> Adopters { get; set; }
      //  public virtual ICollection<Employee> Employee { get; set; }






    }
}
