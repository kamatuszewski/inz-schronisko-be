using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalShelter.Domain.Entities
{
    public partial class Volunteer
    {
        public int Id { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Attendance { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsActive { get; set; }

        public virtual Person IdNavigation { get; set; }
    }
}
