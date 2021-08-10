using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Role
{
    public class AddRoleToPersonRequest
    {
        [Required]
        public int RoleId { get; set; }
    }
}
