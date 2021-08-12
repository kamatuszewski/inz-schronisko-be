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
                throw new BadRequestException("PERSON_NOT_FOUND");
            }

            var role = _context.Role.FirstOrDefault(r => r.Id == request.RoleId);
            if (role is null)
            {
                throw new BadRequestException("ROLE_NOT_FOUND");
            }

            var grantetRoleExists = _context.GrantedRole.FirstOrDefault(gr => gr.PersonId == PersonId && gr.RoleId == request.RoleId);
            if (grantetRoleExists is not null)
            {
                throw new BadRequestException("USER_ROLE_EXISTS");
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
                throw new BadRequestException("PERSON_NOT_FOUND");
            }

            var role = _context.Role.FirstOrDefault(r => r.Id == request.RoleId);
            if (role is null)
            {
                throw new BadRequestException("ROLE_NOT_FOUND");
            }

            var grantetRoleToRemoveExists = _context.GrantedRole.FirstOrDefault(gr => gr.PersonId == PersonId && gr.RoleId == request.RoleId);
            if (grantetRoleToRemoveExists is null)
            {
                throw new BadRequestException("USER_ROLE_DONT_EXIST");
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

/*                    var volunteerToSoftDelete = new Volunteer()
                    {
                        Id = grantedRoleToRemove.PersonId,
                        IsRoleActive = false
                    };*/

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
                    var newVolunteer = _mapper.Map<Volunteer>(request);
                    newVolunteer.Id = grantedRoleEntity.PersonId;
                    _context.Volunteer.Add(newVolunteer);
                    _context.SaveChanges();
                    break;
                case 5: //Vet

                    
                    var empExists = _context.Employee.FirstOrDefault(gr => gr.Id == grantedRoleEntity.PersonId);
                    if (empExists is not null)
                    {
                        var newVet = _mapper.Map<Vet>(request);
                        newVet.Id = grantedRoleEntity.PersonId;
                        _context.Vet.Add(newVet);
                        _context.SaveChanges();

                    } else //we are creating Vet so Emp Entity IsRoleActive should be set to false 
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
                    var newEmpl = _mapper.Map<Employee>(request);
                    newEmpl.Id = grantedRoleEntity.PersonId;
                    _context.Employee.Add(newEmpl);

                    _context.SaveChanges();
                    break;

                default:
                    break;
            }
        }
    }
}
