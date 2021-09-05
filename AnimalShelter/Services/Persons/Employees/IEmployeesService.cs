using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs;
using AnimalShelter_WebAPI.DTOs.Person.Employee.Responses;
using AnimalShelter_WebAPI.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Services.Persons.Employees
{
    public interface IEmployeesService
    {
        public PageResponse<GeneralEmployeeResponse> GetEmplyees(GetEmployeesRequest getEmployeesRequest);
        public DetailedEmployeeResponse GetEmplyee(int id);
        public void EditEmployee(int id, EditEmployeeRequest editEmployeeRequest);
    }
}
