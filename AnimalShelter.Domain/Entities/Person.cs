using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalShelter.Domain.Entities
{
    public partial class Person
    {
        public Person()
        {
            GrantedRoles = new HashSet<GrantedRole>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public string Sex { get; set; }
        public string ContactInfo { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsActive { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual Adopter Adopter { get; set; }
        public virtual Director Director { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Volunteer Volunteer { get; set; }
        public virtual ICollection<GrantedRole> GrantedRoles { get; set; }
    }
}
