using AnimalShelter.Models;
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
                .ToList();
            return _mapper.Map<IEnumerable<GeneralVetResponse>>(vets);
        }

        public DetailedVetResponse GetVet(int id)
        {
            var vet = _context.Vet.Where(a => a.Id == id)
                .Include(req => req.Employee).ThenInclude(req => req.Person)
                .Include(req => req.Vet_Specialties).ThenInclude(req => req.Specialty)
                .FirstOrDefault();
            return _mapper.Map<DetailedVetResponse>(vet);
        }


        public void RemoveSpecialty(int id)
        {
            var specialty = _context.Specialty.Where(a => a.Id == id)
               .FirstOrDefault();
            if (specialty is null) throw new NotFoundException("SPECIALTY_NOT_FOUND");

            _context.Specialty.Remove(specialty);
            _context.SaveChanges();
        }

  

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

        public void AddSpecialtyToVet(int VetId, AddSpecialtyToVetRequest addSpecialtyToVetRequest)
        {
            var vet = _context.Vet.FirstOrDefault(p => p.Id == VetId);
            if (vet is null)
                throw new BadRequestException("VET_NOT_EXISTS");

            var specialty = _context.Specialty.FirstOrDefault(r => r.Id == addSpecialtyToVetRequest.SpecialtyId);
            if (specialty is null)
                throw new BadRequestException("SPECIALTY_NOT_EXISTS");

            var existingSpecialtyCheck = _context.Vet_Specialty.FirstOrDefault(gr => gr.VetId == VetId && gr.SpecialtyId == addSpecialtyToVetRequest.SpecialtyId);
            if (existingSpecialtyCheck is not null)
                throw new BadRequestException("ALREADY_GRANTED");

            var vet_specialty = _mapper.Map<Vet_Specialty>(addSpecialtyToVetRequest);
            vet_specialty.VetId = VetId;

            _context.Vet_Specialty.Add(vet_specialty);
            _context.SaveChanges();

        }
    }
}