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
           var person = _context.Person.ToList();
           return _mapper.Map<IEnumerable<PersonResponse>>(person);
        }

        public PersonResponse GetPerson(int Id)
        {
            var person = _context.Person.Where(a => a.Id == Id)
               .FirstOrDefault();
            return _mapper.Map<PersonResponse>(person);
        }
    }
}
