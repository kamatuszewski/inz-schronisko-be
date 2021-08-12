using AnimalShelter_WebAPI.DTOs.Person.Vet.Responses;
using AnimalShelter_WebAPI.DTOs.Role.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Person.Employee.Responses
{
    public class GeneralEmployeeResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }                       //Vet Only
        [JsonPropertyName("specialties")]
        public IEnumerable<SpecialtyResponse> SpecialtyResponses { get; set; }  //Vet only
        [JsonPropertyName("roles")]
        public IEnumerable<RoleResponse> roleResponses { get; set; }
    }
}
