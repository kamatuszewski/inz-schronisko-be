﻿using AnimalShelter.DTOs.Responses;
using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.Animal.Responses;
using AnimalShelter_WebAPI.DTOs.Requests;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Services
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


        public FullDataAnimalResponse GetAnimal(int id)
        {
            var animal = _context.Animal.Where(a => a.Id == id)
                .Include(req => req.Species)
                .Include(req => req.Status)
                .Include(req => req.Adoptions).ThenInclude(ad => ad.Adopter)
                .Include(req => req.Adoptions).ThenInclude(ad => ad.AdoptionOfficeWorker).ThenInclude(aow => aow.Employee).ThenInclude(emp => emp.Person)
                .Include(req => req.VetVisits)
                .FirstOrDefault();

            return _mapper.Map<FullDataAnimalResponse>(animal);
              
        }


        public IEnumerable<GeneralAnimalResponse> GetAnimals()
        {
            var animals = _context.Animal
                .Include(req => req.Species)
                .Include(req => req.Status)
                .ToList();
             return _mapper.Map<IEnumerable<GeneralAnimalResponse>>(animals);
        }

        public Animal CreateAnimal(CreateAnimalRequest createAnimalRequest)
        {
           
                var animal = _mapper.Map<Animal>(createAnimalRequest);
                _context.Animal.Add(animal);
                _context.SaveChanges();

                return animal;
            
        }

        public bool RemoveAnimal(int id)
        {
            var animal = _context.Animal.Where(a => a.Id == id)
               .FirstOrDefault();

            if (animal is null) return false;

            _context.Animal.Remove(animal);
            _context.SaveChanges();

            return true;

        }
    }
}
