using AnimalShelter.DTOs.Responses;
using AnimalShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Services
{
    public class PersonsDbService : IPersonsDbService
    {
        private readonly ShelterDbContext _context;
        public PersonsDbService(ShelterDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Person> GetPersons()
        {
            //jak moge zwrocic response zamiast student? Teraz zwraca mi za duzo danych przez uzycie EF
            var personResponse = new PersonResponse();
            return _context.Person.ToList();
        }

        public IPersonsDbService GetPerson(int id)
        {
            //code to be added
            throw new NotImplementedException();
        }
    }
}
