using AnimalShelter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Requests
{
    public class RegisterPersonRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PESEL { get; set; }
        public string Sex { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? QuitDate { get; set; }
        public int? Salary { get; set; }
        public string PWZNumber { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string Attendance { get; set; }


    }
}
