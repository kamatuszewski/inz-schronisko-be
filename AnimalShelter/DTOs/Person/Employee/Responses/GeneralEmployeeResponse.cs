using AnimalShelter_WebAPI.DTOs.Person.Vet.Responses;
using AnimalShelter_WebAPI.DTOs.Role.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Person.Employee.Responses
{
    public class GeneralEmployeeResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }                       //Vet Only
        public IEnumerable<SpecialtyResponse> SpecialtyResponses { get; set; }  //Vet only
        public IEnumerable<RoleResponse> roleResponses { get; set; }
    }
}
