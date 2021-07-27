using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalShelter.Domain.Entities
{
    public partial class GrantedRole
    {
        public int IdPerson { get; set; }
        public int IdRole { get; set; }
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsActive { get; set; }

        public virtual Person IdPersonNavigation { get; set; }
        public virtual Role IdRoleNavigation { get; set; }
    }
}
