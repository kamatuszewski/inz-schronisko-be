using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Person.Vet.Responses
{
    public class DetailedVetResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PESEL { get; set; }
        public string Sex { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? QuitDate { get; set; }
        public int Salary { get; set; }
        public string PwzNumber { get; set; }
        //    public bool IsRoleActive { get; set; }

        [JsonPropertyName("specialties")]
        public IEnumerable<ObtainedSpecialtyResponse> SpecialtyResponses { get; set; }
    }
}
