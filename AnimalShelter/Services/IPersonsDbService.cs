
using AnimalShelter.DTOs.Responses;
using AnimalShelter.Models;
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
        //--- to be added

        public IEnumerable<PersonResponse> GetPersons();
    }
}


