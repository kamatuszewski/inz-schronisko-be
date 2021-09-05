﻿using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.Person.Vet.Requests;
using AnimalShelter_WebAPI.DTOs.Person.Vet.Responses;
using AnimalShelter_WebAPI.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Services
{ 
    public class VetsService : IVetsService
    {
        private readonly ShelterDbContext _context;
        private readonly IMapper _mapper;
        public VetsService(ShelterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<GeneralVetResponse> GetVets()
        {
            var vets = _context.Vet
                .Include(req => req.Employee).ThenInclude(req => req.Person)
                .Include(req => req.Vet_Specialties).ThenInclude(req => req.Specialty)
                .Where(x => x.IsRoleActive == true)
                .ToList();
            return _mapper.Map<IEnumerable<GeneralVetResponse>>(vets);
        }

        public DetailedVetResponse GetVet(int id)
        {
            var vet = _context.Vet.Where(a => a.Id == id)
                .Include(req => req.Employee).ThenInclude(req => req.Person)
                .Include(req => req.Vet_Specialties).ThenInclude(req => req.Specialty)
                .FirstOrDefault();

            if (vet is null)
                throw new NotFoundException("VET_NOT_FOUND");

            return _mapper.Map<DetailedVetResponse>(vet);
        }

        public void AddSpecialtiesToVet(int VetId, AddSpecialtiesToVetRequest addSpecialtiesToVetRequest)
        {
            var vet = _context.Vet.FirstOrDefault(p => p.Id == VetId);
            if (vet is null)
                throw new BadRequestException("VET_NOT_EXISTS");

                var specialtyAddedExists = _context.Vet_Specialty.FirstOrDefault(vs => vs.SpecialtyId == addSpecialtiesToVetRequest.SpecialtyId && vs.VetId == VetId);
                if (specialtyAddedExists is not null)
                    specialtyAddedExists.ObtainingDate = addSpecialtiesToVetRequest.ObtainingDate;
                else
                {
                    var vet_specialty = new Vet_Specialty()
                    {
                        VetId = VetId,
                        SpecialtyId = addSpecialtiesToVetRequest.SpecialtyId,
                        ObtainingDate = addSpecialtiesToVetRequest.ObtainingDate
                    };

                _context.Vet_Specialty.Add(vet_specialty);

               
                  }
            _context.SaveChanges();
            


        }

        public void RemoveSpecialtyFromVet(int VetId, int SpecialtyId)
        {
            var vet = _context.Vet.FirstOrDefault(p => p.Id == VetId);
            if (vet is null)
                throw new BadRequestException("VET_NOT_EXISTS");

            var specialty = _context.Specialty.FirstOrDefault(r => r.Id == SpecialtyId);
            if (specialty is null)
                throw new BadRequestException("SPECIALTY_NOT_EXISTS");

            var vet_spec = _context.Vet_Specialty.FirstOrDefault(gr => gr.VetId == VetId && gr.SpecialtyId == SpecialtyId);
            if (vet_spec is null)
                throw new BadRequestException("NOT_GRANTED");

            _context.Vet_Specialty.Remove(vet_spec);
            _context.SaveChanges();

        }

        //specialties details
        public IEnumerable<SpecialtyResponse> GetSpecialties()
        {
            var specialties = _context.Specialty
               .ToList();
            return _mapper.Map<IEnumerable<SpecialtyResponse>>(specialties);
        }

        public Specialty CreateSpecialty(CreateSpecialtyRequest createSpecialtyRequest)
        {
             var specialty = _mapper.Map<Specialty>(createSpecialtyRequest);
            _context.Specialty.Add(specialty);
            _context.SaveChanges();
            return specialty;
        }

        public void RemoveSpecialty(int id)
        {
            var specialty = _context.Specialty.Where(a => a.Id == id)
               .FirstOrDefault();
            if (specialty is null) throw new NotFoundException("SPECIALTY_NOT_FOUND");

            _context.Specialty.Remove(specialty);
            _context.SaveChanges();
        }


    }
}