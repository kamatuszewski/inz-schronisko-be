using AnimalShelter.DTOs.Responses;
using AnimalShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Services
{
    public interface IAnimalsService
    {
        public GeneralAnimalResponse GetAnimal(int shelterNumber);
        //--- to be added

        public IEnumerable<GeneralAnimalResponse> GetAnimals();
    }
}
