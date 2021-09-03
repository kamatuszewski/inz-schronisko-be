using AnimalShelter.DTOs.Responses;
using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs;
using AnimalShelter_WebAPI.DTOs.Animal.Requests;
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
        public PageResponse<GeneralAnimalResponse> GetAnimals(GetAnimalsRequest getAnimalsRequest);
        public FullDataAnimalResponse GetAnimal(int id);
        public void RemoveAnimal(int id);
        public void CreateAnimal(CreateAnimalRequest createAnimalRequest);
        public void UpdateAnimal(int id, UpdateAnimalRequest updateAnimalRequest);
        public IEnumerable<StatusesResponse> GetStatuses();
        public IEnumerable<SpeciesResponse> GetSpecies();
    }
}
