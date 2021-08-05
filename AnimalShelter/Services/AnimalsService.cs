using AnimalShelter.DTOs.Responses;
using AnimalShelter.Models;
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


        public GeneralAnimalResponse GetAnimal(int id)
        {
            var animal = _context.Animal.Where(a => a.Id == id)
                .Include(req => req.Species)
                .Include(req => req.Status)
                .FirstOrDefault();
            return _mapper.Map<GeneralAnimalResponse>(animal);
              
        }

        public IEnumerable<GeneralAnimalResponse> GetAnimals()
        {
            var animals = _context.Animal
                .Include(req => req.Species)
                .Include(req => req.Status)
                .ToList();
             return _mapper.Map<IEnumerable<GeneralAnimalResponse>>(animals);
        }
    }
}
