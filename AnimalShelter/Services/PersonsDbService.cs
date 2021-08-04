using AnimalShelter.DTOs.Responses;
using AnimalShelter.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Services
{
    public class PersonsDbService : IPersonsDbService
    {
        private readonly ShelterDbContext _context;
        private readonly IMapper _mapper;

        public PersonsDbService(ShelterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public IEnumerable<PersonResponse> GetPersons()
        {
            var persons = _context.Person.ToList();
            return _mapper.Map<IEnumerable<PersonResponse>>(persons);
        }

        public PersonResponse GetPerson(int id)
        {
            var person = _context.Person.Where(a => a.Id == id)
                .FirstOrDefault();
            return _mapper.Map<PersonResponse>(person);
        }
    }
}
