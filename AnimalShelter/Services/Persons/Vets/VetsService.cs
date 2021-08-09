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
            if (specialty is null) throw new NotFoundException("Specialty not found");

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
    }
}