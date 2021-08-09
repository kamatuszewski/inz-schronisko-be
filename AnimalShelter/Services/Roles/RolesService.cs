﻿using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.Role;
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
        void AddRoleToPerson(int personId, AddRoleToPersonRequest request);
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
        public void AddRoleToPerson(int personId, AddRoleToPersonRequest request)
        {
            var person = _context.Person.FirstOrDefault(p => p.Id == personId);

            if (person is null)
            {
                throw new BadRequestException("Person not found");
            }

            var role = _context.Role.FirstOrDefault(r => r.Id == request.IdRole);
            if (role is null)
            {
                throw new BadRequestException("Role not found");
            }

            var grantetRoleExists = _context.GrantedRole.FirstOrDefault(gr => gr.IdPerson == personId && gr.IdRole == request.IdRole);
            if (grantetRoleExists is not null)
            {
                throw new BadRequestException("User with that role is already exist");
            }

            var grantedRoleEntity = _mapper.Map<GrantedRole>(request);
            grantedRoleEntity.IdPerson = personId;

            _context.GrantedRole.Add(grantedRoleEntity);
            _context.SaveChanges();

        }
    }
}
