using AnimalShelter.DTOs;
using AnimalShelter.DTOs.Responses;
using AnimalShelter.Models;
using AnimalShelter_WebAPI;
using AnimalShelter_WebAPI.DTOs.Requests;
using AnimalShelter_WebAPI.Exceptions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Services
{
    public class PersonsService : IPersonsService
    {


        private readonly ShelterDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Person> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        public PersonsService(ShelterDbContext context, IMapper mapper, IPasswordHasher<Person> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _context = context;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
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



       //Adopter usunięty - to będzie po prostu osoba
/*

        public Adopter CreateAdopter(CreateAdopterRequest createAdopterRequest)
        {
            var adopter = _mapper.Map<Adopter>(createAdopterRequest);
            _context.Adopter.Add(adopter);
            _context.SaveChanges();

            return adopter;
        }
*/

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
                PersonId = newPerson.Id,
                RoleId = registerPersonRequest.RoleId
            };


            _context.GrantedRole.Add(newGrantedRole);
            _context.SaveChanges();

        }

        public string GenerateJwt(LoginRequest request)
        {

            var person = _context.Person
                .Include(p => p.GrantedRoles)
                .FirstOrDefault(p => p.EmailAddress == request.EmailAddress);

            if (person is null)
            {
                throw new BadRequestException("Nieprawidłowy login lub haslo");
            }

            var result = _passwordHasher.VerifyHashedPassword(person, person.Password, request.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Nieprawidłowy login lub haslo");
            }

            var roles = person.GrantedRoles;
            Console.WriteLine(roles);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, person.Id.ToString()),
                new Claim("FirstName", $"{person.FirstName}"),
                new Claim("LastName", $"{person.LastName}")
            };


            
            //adding clams for Roles 
                foreach (var role in person.GrantedRoles)
            {
                var roleName = _context.GrantedRole
                .Include(p => p.Role)
                .FirstOrDefault( p => p.IdRole == role.IdRole);

                claims.Add(new Claim(ClaimTypes.Role, roleName.Role.Name));
            }
              
        
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddHours(_authenticationSettings.JwtExpireHours);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred
                );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);

/*            //   Student s = _studentDbService.CheckPass(request.Login, request.Haslo);


            if (s == null)
            {
                return NotFound("Zly login lub haslo");
            }


            //nie kumaaaam, czemu to jest na sztywno, skad mma wiedziec ile rol etc.
            var userclaim = new[]
                {
                new Claim(ClaimTypes.Name, "mj"),
                new Claim(ClaimTypes.Role, "user1"),
                new Claim(ClaimTypes.Role, "admin"),
                };



            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken
            (
                issuer: "http://localhost:5001",
                audience: "http://localhost:5001",
                claims: userclaim,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            var refreshToken = Guid.NewGuid();
            //  s.refToken = refreshToken.ToString();
            //  _studentDbService.setToken(s, refreshToken);

            return Ok(new
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(token),
                refreshToken
            });*/
        }
    }
}
