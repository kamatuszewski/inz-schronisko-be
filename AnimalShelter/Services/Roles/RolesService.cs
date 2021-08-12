using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.Role;
using AnimalShelter_WebAPI.DTOs.Role.Requests;
using AnimalShelter_WebAPI.Exceptions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Services.Roles
{
    public interface IRolesService
    {
        void AddRoleToPerson(int PersonId, AddRoleToPersonRequest request);
        void RemoveRoleFromPerson(int PersonId, RemoveRoleFromPersonRequest request);
    }
    public class RolesService: IRolesService
    {
        private readonly ShelterDbContext _context;
        private readonly IMapper _mapper;

        public RolesService(ShelterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void AddRoleToPerson(int PersonId, AddRoleToPersonRequest request)
        {
            var person = _context.Person.FirstOrDefault(p => p.Id == PersonId);

            if (person is null)
            {
                throw new NotFoundException("PERSON_NOT_FOUND");
            }

            var role = _context.Role.FirstOrDefault(r => r.Id == request.RoleId);
            if (role is null)
            {
                throw new NotFoundException("ROLE_NOT_FOUND");
            }

            var grantetRoleExists = _context.GrantedRole.FirstOrDefault(gr => gr.PersonId == PersonId && gr.RoleId == request.RoleId);
            if (grantetRoleExists is not null)
            {
                throw new NotFoundException("USER_ROLE_EXISTS");
            }

            
            var grantedRoleEntity = _mapper.Map<GrantedRole>(request);
            grantedRoleEntity.PersonId = PersonId;


            // method need to create Vet/Emp/Volunteer DB entities
            CreateEntitiesBasedOnPersonRole(grantedRoleEntity, request);

            _context.GrantedRole.Add(grantedRoleEntity);
            _context.SaveChanges();

        }

        public void RemoveRoleFromPerson(int PersonId, RemoveRoleFromPersonRequest request)
        {
            var person = _context.Person.FirstOrDefault(p => p.Id == PersonId);

            if (person is null)
            {
                throw new NotFoundException("PERSON_NOT_FOUND");
            }

            var role = _context.Role.FirstOrDefault(r => r.Id == request.RoleId);
            if (role is null)
            {
                throw new NotFoundException("ROLE_NOT_FOUND");
            }

            var grantetRoleToRemoveExists = _context.GrantedRole.FirstOrDefault(gr => gr.PersonId == PersonId && gr.RoleId == request.RoleId);
            if (grantetRoleToRemoveExists is null)
            {
                throw new NotFoundException("USER_ROLE_DONT_EXIST");
            }

            SoftDeleteEntitiesBasedOnPersonRole(grantetRoleToRemoveExists, request);

            _context.GrantedRole.Remove(grantetRoleToRemoveExists);
            _context.SaveChanges();
        }

        private void SoftDeleteEntitiesBasedOnPersonRole(GrantedRole grantedRoleToRemove, RemoveRoleFromPersonRequest request)
        {
            switch (request.RoleId)
            {
                case 1: //Volunteer

                    var volunteerToSoftDelete = _context.Volunteer.FirstOrDefault(v => v.Id == grantedRoleToRemove.PersonId);
                    volunteerToSoftDelete.IsRoleActive = false;

                    _context.Volunteer.Update(volunteerToSoftDelete);
                    _context.SaveChanges();
                    break;
                case 5: //Vet
                    var vetToSoftDelete = _context.Vet.FirstOrDefault(v => v.Id == grantedRoleToRemove.PersonId);
                    vetToSoftDelete.IsRoleActive = false;

                    _context.Vet.Update(vetToSoftDelete);
                    _context.SaveChanges();
                    break;
                case 2: //Emp
                    var empToSoftDelete = _context.Employee.FirstOrDefault(v => v.Id == grantedRoleToRemove.PersonId);
                    empToSoftDelete.IsRoleActive = false;
                    empToSoftDelete.QuitDate = request.QuitDate;

                    _context.Employee.Update(empToSoftDelete);
                    _context.SaveChanges();
                    break;

                default:
                    break;
            }
        }

        private void CreateEntitiesBasedOnPersonRole(GrantedRole grantedRoleEntity, AddRoleToPersonRequest request)
        {
            switch (request.RoleId)
            {
                case 1: //Volunteer
                    var volunteerExists = _context.Volunteer.FirstOrDefault(gr => gr.Id == grantedRoleEntity.PersonId);
                    if (volunteerExists is not null)
                    {
                        volunteerExists.IsRoleActive = true;
                        volunteerExists.JoiningDate = (DateTime)request.JoiningDate;
                        volunteerExists.Attendance = request.Attendance;
                        _context.Volunteer.Update(volunteerExists);
                        _context.SaveChanges();
                    }
                    else
                    {
                        var newVolunteer = _mapper.Map<Volunteer>(request);
                        newVolunteer.Id = grantedRoleEntity.PersonId;
                        _context.Volunteer.Add(newVolunteer);
                        _context.SaveChanges();
                    }
                    break;

                case 5: //Vet

                    var empExists = _context.Employee.FirstOrDefault(gr => gr.Id == grantedRoleEntity.PersonId);
                    if (empExists is not null)
                    {
                        var vetExists = _context.Vet.FirstOrDefault(gr => gr.Id == grantedRoleEntity.PersonId);
                        if (vetExists is not null)
                        {
                            vetExists.IsRoleActive = true;
                            vetExists.PWZNumber = request.PWZNumber;
                            _context.Vet.Update(vetExists);
                            _context.SaveChanges();

                        } else
                        {
                            var newVet = _mapper.Map<Vet>(request);
                            newVet.Id = grantedRoleEntity.PersonId;
                            _context.Vet.Add(newVet);
                            _context.SaveChanges();
                        }

                    } else  
                    {
                        var newEmp = _mapper.Map<Employee>(request);
                        newEmp.Id = grantedRoleEntity.PersonId;
                        newEmp.IsRoleActive = false;
                        _context.Employee.Add(newEmp);

                        var newVet = _mapper.Map<Vet>(request);
                        newVet.Id = grantedRoleEntity.PersonId;
                        _context.Vet.Add(newVet);
                        _context.SaveChanges();
                    }
                    break;

                case 2: //Emp

                    var empExists2 = _context.Employee.FirstOrDefault(gr => gr.Id == grantedRoleEntity.PersonId);
                    if (empExists2 is not null)
                    {
                        empExists2.IsRoleActive = true;
                        empExists2.HireDate = (DateTime)request.HireDate;
                        empExists2.Salary = request.Salary;
                        empExists2.QuitDate = null;
                        _context.Employee.Update(empExists2);
                        _context.SaveChanges();

                    } else
                    {
                        var newEmpl = _mapper.Map<Employee>(request);
                        newEmpl.Id = grantedRoleEntity.PersonId;
                        _context.Employee.Add(newEmpl);
                        _context.SaveChanges();
                    }

                    break;
                default:
                    break;
            }
        }
    }
}
