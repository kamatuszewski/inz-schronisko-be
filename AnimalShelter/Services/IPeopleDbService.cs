using AnimalShelter.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AnimalShelter.Services

{
    public interface IPeopleDbService
    {
        public IPeopleDbService GetPerson(int id);
        //--- to be added

        public IEnumerable<Person> GetPeople();
    }
}


