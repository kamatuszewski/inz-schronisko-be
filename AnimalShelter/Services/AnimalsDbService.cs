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
    public class AnimalsDbService : IAnimalsDbService
    {
        private readonly ShelterDbContext _context;
        private readonly IMapper _mapper;
        public AnimalsDbService(ShelterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public AnimalResponse GetAnimal(int shelterNumber)
        {
            var animal = _context.Animal.Where(a => a.ShelterNumber == shelterNumber)
                .Include(req => req.Species)
                .Include(req => req.Status)
                .FirstOrDefault();
            return _mapper.Map<AnimalResponse>(animal);
              
        }

        public IEnumerable<AnimalResponse> GetAnimals()
        {
            var animals = _context.Animal.ToList();
             return _mapper.Map<IEnumerable<AnimalResponse>>(animals);
        }
    }
}
