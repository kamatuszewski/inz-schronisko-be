using AnimalShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Services
{
    public class EfPeopleDbService : IPeopleDbService
    {
        private readonly PeopleDbContext _context;
        public EfPeopleDbService(PeopleDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Person> GetPeople()
        {
            return _context.Person.ToList();
        }

        public IPeopleDbService GetPerson(int id)
        {
            //code to be added
            throw new NotImplementedException();
        }
    }
}
