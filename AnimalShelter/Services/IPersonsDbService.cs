
using AnimalShelter.DTOs.Responses;
using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.Requests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AnimalShelter.Services
{
    public interface IPersonsDbService
    {

        public PersonResponse GetPerson(int id);
        public IEnumerable<PersonResponse> GetPersons();
        public Person CreatePerson(CreatePersonRequest createPersonRequest);
        public Adopter CreateAdopter(CreateAdopterRequest createAdopterRequest);
    }
}


