﻿using AnimalShelter_WebAPI.DTOs.Person.Vet.Responses;
using AnimalShelter_WebAPI.DTOs.Role.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Person.Employee.Responses
{
    public class DetailedEmployeeResponse
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
        public int Salary { get; set; }                                              //Vet Only
        public IEnumerable<RoleResponse> roleResponses { get; set; }
        public string PwzNumber { get; set; }                                                   //Vet Only
        public IEnumerable<ObtainedSpecialtyResponse> SpecialtyResponses { get; set; }          //Vet Only
    }
}
