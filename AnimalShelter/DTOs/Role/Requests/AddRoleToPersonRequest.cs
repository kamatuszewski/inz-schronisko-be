using AnimalShelter_WebAPI.DTOs.Person.Vet.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Role
{
    public class AddRoleToPersonRequest
    {
        [Required]
        public int RoleId { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? QuitDate { get; set; }
        public int Salary { get; set; }
        public string PWZNumber { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string Attendance { get; set; }

        [JsonPropertyName("VetSpecialties")]
        public IEnumerable<AddSpecialtiesToVetRequest> VetSpecialties { get; set; }
    }
}
