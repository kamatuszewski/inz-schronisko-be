using AnimalShelter.DTOs.Responses;
using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs;
using AnimalShelter_WebAPI.DTOs.Animal.Requests;
using AnimalShelter_WebAPI.DTOs.Animal.Responses;
using AnimalShelter_WebAPI.DTOs.Requests;
using AnimalShelter_WebAPI.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public PageResponse<GeneralAnimalResponse> GetAnimals(GetAnimalsRequest getAnimalsRequest)
        {
            var baseAnimals = _context.Animal
                .Include(req => req.Species)
                .Include(req => req.Status)
                .Where(r => getAnimalsRequest.StatusId == null || r.StatusId.Equals(getAnimalsRequest.StatusId))
                .Where(r => getAnimalsRequest.SpeciesId == null || r.SpeciesId.Equals(getAnimalsRequest.SpeciesId))
                .Where(r => getAnimalsRequest.Sex == null || r.Sex.Equals(getAnimalsRequest.Sex))
                .Where(r => getAnimalsRequest.Name == null || r.ChipNumber.Equals(getAnimalsRequest.Name));

            if (!string.IsNullOrEmpty(getAnimalsRequest.SortBy))
            {
                var columnsSelector = new Dictionary<string, Expression<Func<Animal, object>>>
                 (StringComparer.InvariantCultureIgnoreCase)
                {
                    { nameof(Animal.ChipNumber), r => r.ChipNumber},
                    { nameof(Animal.Name), r => r.Name},
                    { nameof(Animal.Sex), r => r.Sex},
                    { nameof(Animal.Species), r => r.Species},
                    { nameof(Animal.BirthDate), r => r.BirthDate},
                    { nameof(Animal.FoundDate), r => r.FoundDate},
                    { nameof(Animal.Status), r => r.Status}

                };
                var selectedColumn = columnsSelector[getAnimalsRequest.SortBy];

                baseAnimals = getAnimalsRequest.SortDirection == SortDirection.ASC
                    ? baseAnimals.OrderBy(selectedColumn)
                    : baseAnimals.OrderByDescending(selectedColumn);
            }


            var returnAnimals = baseAnimals
                .Skip(getAnimalsRequest.pageSize * (getAnimalsRequest.pageNumber - 1))
                .Take(getAnimalsRequest.pageSize)
                .ToList();

            var totalItemsCount = baseAnimals.Count();

            var animalsList =  _mapper.Map<IEnumerable<GeneralAnimalResponse>>(returnAnimals);
            var result = new PageResponse<GeneralAnimalResponse>(animalsList, totalItemsCount, getAnimalsRequest.pageSize, getAnimalsRequest.pageNumber );
            return result;
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
