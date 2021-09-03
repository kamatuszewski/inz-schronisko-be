using AnimalShelter.DTOs.Responses;
using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.Animal.Requests;
using AnimalShelter_WebAPI.DTOs.Animal.Responses;
using AnimalShelter_WebAPI.DTOs.Requests;
using AnimalShelter_WebAPI.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Services.Animals
{
    public class AnimalsService : IAnimalsService
    {
        private readonly ShelterDbContext _context;
        private readonly IMapper _mapper;
        public AnimalsService(ShelterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<GeneralAnimalResponse> GetAnimals(string species, int? chipNr, string status)
        {
            var animals = _context.Animal
                .Include(req => req.Species)
                .Include(req => req.Status)
                .Where(r => species == null || r.Species.Name.ToLower().Contains(species.ToLower()))
                .Where(r => chipNr == null || r.ChipNumber.Equals(chipNr))
                .Where(r => status == null || r.Status.Name.ToLower().Contains(status.ToLower()))
                .ToList();

             return _mapper.Map<IEnumerable<GeneralAnimalResponse>>(animals);
        }

        public FullDataAnimalResponse GetAnimal(int id)
        {
            var animal = _context.Animal.Where(a => a.Id == id)
                .Include(req => req.Species)
                .Include(req => req.Status)
                .Include(req => req.Adoptions).ThenInclude(ad => ad.Adopter)
                .Include(req => req.Adoptions)
                          .ThenInclude(e => e.Employee).ThenInclude(emp => emp.Person)
                .Include(req => req.VetVisits)
                .FirstOrDefault();

            if (animal is null)
                throw new BadRequestException("ANIMAL_NOT_FOUND");

            return _mapper.Map<FullDataAnimalResponse>(animal);
        }

        public void CreateAnimal(CreateAnimalRequest createAnimalRequest)
        {
            var animal = _mapper.Map<Animal>(createAnimalRequest);
            _context.Animal.Add(animal);
            _context.SaveChanges();

        }

        public void UpdateAnimal(int id, UpdateAnimalRequest updateAnimalRequest)
        {
            var animal = _context.Animal.Where(a => a.Id == id)
             .FirstOrDefault();

            if (animal is null) 
                throw new NotFoundException("ANIMAL_NOT_FOUND");

            
            animal.Name = updateAnimalRequest.Name;
            animal.StatusId = updateAnimalRequest.StatusId;
            animal.FoundPlace = updateAnimalRequest.FoundPlace;

            _context.SaveChanges();
        }


        public void RemoveAnimal(int id)
        {
            var animal = _context.Animal.Where(a => a.Id == id)
               .FirstOrDefault();

            if (animal is null) 
                throw new NotFoundException("ANIMAL_NOT_FOUND");

            _context.Animal.Remove(animal);
            _context.SaveChanges();

        }

        public IEnumerable<StatusesResponse> GetStatuses()
        {
            var statuses = _context.Status
                .ToList();
            return _mapper.Map<IEnumerable<StatusesResponse>>(statuses);
        }

        public IEnumerable<SpeciesResponse> GetSpecies()
        {
            var species = _context.Species
                .ToList();
            return _mapper.Map<IEnumerable<SpeciesResponse>>(species);
        }
    }
}
