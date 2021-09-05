using AnimalShelter_WebAPI.DTOs.Person.Vet.Responses;
using AnimalShelter_WebAPI.DTOs.Role.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace AnimalShelter.DTOs.Responses
{
    public class PersonResponse 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PESEL { get; set; }
        public string Sex { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }

        [JsonPropertyName("roles")]
        public IEnumerable<RoleResponse> Roles { get; set; }
        [JsonPropertyName("specialties")]
        public IEnumerable<ObtainedSpecialtyResponse> SpecialtyResponses { get; set; }
    }
}
