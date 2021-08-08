using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Animal.Responses
{
    public class AdoptionResponse
    {
        public int Id { get; set; }
        public DateTime AdoptionDate { get; set; }
        public DateTime? ControlDate { get; set; }
        [JsonPropertyName("employee")]
        public EmployeeResponse EmployeeResponse { get; set; }
        [JsonPropertyName("adopter")]
        public AdopterResponse AdopterResponse { get; set; }


    }
}
