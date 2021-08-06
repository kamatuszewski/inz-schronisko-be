using AnimalShelter.DTOs.Responses;
using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.Requests;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Services
{
    public class PersonsService : IPersonsService
    {


        private readonly ShelterDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Person> _passwordHasher;
        public PersonsService(ShelterDbContext context, IMapper mapper, IPasswordHasher<Person> passwordHasher)
        {
            _context = context;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
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

        //// ta metoa jest raczej do wyrzucenia - CreatePerson = RegisterUser moim zdaniem 
        //public Person CreatePerson(CreatePersonRequest createPersonRequest)
        //{
        //    var person = _mapper.Map<Person>(createPersonRequest);
        //    _context.Person.Add(person);
        //    _context.SaveChanges();

        //    return person;
        //}



        public Adopter CreateAdopter(CreateAdopterRequest createAdopterRequest)
        {
            var adopter = _mapper.Map<Adopter>(createAdopterRequest);
            _context.Adopter.Add(adopter);
            _context.SaveChanges();

            return adopter;
        }


        public void RegisterPerson(RegisterPersonRequest registerPersonRequest)
        {
            var newPerson = new Person()
            {
                EmailAddress = registerPersonRequest.EmailAddress,
                FirstName = registerPersonRequest.FirstName,
                LastName = registerPersonRequest.LastName,
                PESEL = registerPersonRequest.PESEL,
                Sex = registerPersonRequest.Sex
                //GrantedRoles = new GrantedRole { IdPerson = Id, IdRole = registerPersonRequest.IdRole}
            };

            var hashedPassword = _passwordHasher.HashPassword(newPerson, registerPersonRequest.Password);
            newPerson.Password = hashedPassword;

            _context.Person.Add(newPerson);
            _context.SaveChanges();

            var newGrantedRole = new GrantedRole()
            {
                IdPerson = newPerson.Id,
                IdRole = registerPersonRequest.IdRole
            };

            
            _context.GrantedRole.Add(newGrantedRole);
            _context.SaveChanges();

        }
    }
}
