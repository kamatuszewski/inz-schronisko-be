using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Role.Requests
{
    public class RemoveRoleFromPersonRequest
    {
        public int RoleId { get; set; }
        public DateTime? QuitDate { get; set; }
    }
}
