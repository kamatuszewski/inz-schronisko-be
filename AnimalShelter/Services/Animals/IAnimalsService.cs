using AnimalShelter.DTOs.Responses;
using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.Animal.Responses;
using AnimalShelter_WebAPI.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Services.Animals
{
    public interface IAnimalsService
    {
        public IEnumerable<GeneralAnimalResponse> GetAnimals();
        public FullDataAnimalResponse GetAnimal(int shelterNumber);
        public bool RemoveAnimal(int id);
        public Animal CreateAnimal(CreateAnimalRequest createAnimalRequest);

        public IEnumerable<StatusesResponse> GetStatuses();
        public IEnumerable<SpeciesResponse> GetSpecies();
    }
}
