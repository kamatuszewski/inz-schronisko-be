using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.Person.Vet.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Requests
{
    public class RegisterPersonRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PESEL { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? QuitDate { get; set; }
        public int? Salary { get; set; }
        public string PWZNumber { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string Attendance { get; set; }

        [JsonPropertyName("VetSpecialties")]
        public IEnumerable<AddSpecialtiesToVetRequest> VetSpecialties { get; set; }

    }
}
