﻿using AnimalShelter_WebAPI.DTOs.Person.Employee.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Services.Persons.Employees
{
    public interface IEmployeesService
    {
        public IEnumerable<GeneralEmployeeResponse> GetEmplyees();
        public DetailedEmployeeResponse GetEmplyee(int id);
    }
}
