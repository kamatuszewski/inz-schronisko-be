using AnimalShelter.DTOs.Responses;
using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Services
{
    public interface IAnimalsService
    {
        public GeneralAnimalResponse GetAnimal(int shelterNumber);

        public bool RemoveAnimal(int id);

        public IEnumerable<GeneralAnimalResponse> GetAnimals();
        public Animal CreateAnimal(CreateAnimalRequest createAnimalRequest);
    }
}
