using AnimalShelter.DTOs.Responses;
using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.Requests;
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

        public Person CreatePerson(CreatePersonRequest createPersonRequest)
        {
            var person = _mapper.Map<Person>(createPersonRequest);
            _context.Person.Add(person);
            _context.SaveChanges();

            return person;
        }

        public Adopter CreateAdopter(CreateAdopterRequest createAdopterRequest)
        {
            var adopter = _mapper.Map<Adopter>(createAdopterRequest);
            _context.Adopter.Add(adopter);
            _context.SaveChanges();

            return adopter;
        }
    }
}
