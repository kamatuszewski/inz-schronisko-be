using AnimalShelter_WebAPI.DTOs.Role.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Person.PersonsGeneral.Responses
{
    public class GeneralPersonResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }

        public IEnumerable<RoleResponse> Roles { get; set; }
    }
}
