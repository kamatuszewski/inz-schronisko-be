using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Person.Vet.Responses
{
    public class GeneralVetResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        //    public bool IsRoleActive { get; set; }

        [JsonPropertyName("specialties")]
        public IEnumerable <SpecialtyResponse> SpecialtyResponses { get; set; }
    }
}
