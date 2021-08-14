using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.Person.Employee.Responses;
using AnimalShelter_WebAPI.DTOs.Requests;
using AnimalShelter_WebAPI.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Services.Persons.Employees
{
    public class EmployeesService : IEmployeesService
    {

        private readonly ShelterDbContext _context;
        private readonly IMapper _mapper;
        public EmployeesService(ShelterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public IEnumerable<GeneralEmployeeResponse> GetEmplyees()
        {
            var employees = _context.Employee
                .Include(req => req.Person).ThenInclude(req => req.GrantedRoles).ThenInclude(req => req.Role)
                .Include(req => req.Vet).ThenInclude(req => req.Vet_Specialties).ThenInclude(req => req.Specialty)
                .Where(req => req.IsRoleActive == true || req.Vet.IsRoleActive==true)
                .ToList();
            return _mapper.Map<IEnumerable<GeneralEmployeeResponse>>(employees);
        }

        public DetailedEmployeeResponse GetEmplyee(int id)
        {
            var employee = _context.Employee.Where(a => a.Id == id)
                 .Include(req => req.Person).ThenInclude(req => req.GrantedRoles).ThenInclude(req => req.Role)
                 .Include(req => req.Vet).ThenInclude(req => req.Vet_Specialties).ThenInclude(req => req.Specialty)
                 .FirstOrDefault();

            if (employee is null)
                throw new NotFoundException("EMPLOYEE_NOT_FOUND");

            return _mapper.Map<DetailedEmployeeResponse>(employee);
        }

        public void EditEmployee(int id, EditEmployeeRequest editEmployeeRequest)
        {
            var employee = _context.Employee.Where(a => a.Id == id)
             .FirstOrDefault();

            if (employee is null)
                throw new NotFoundException("EMPLOYEE_NOT_FOUND");


            employee.Salary = editEmployeeRequest.Salary;
            employee.HireDate = editEmployeeRequest.HireDate;
           
            _context.SaveChanges();
        }
    }
}
