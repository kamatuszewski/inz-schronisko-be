using AnimalShelter.DTOs;
using AnimalShelter.DTOs.Responses;
using AnimalShelter.Models;
using AnimalShelter_WebAPI;
using AnimalShelter_WebAPI.DTOs;
using AnimalShelter_WebAPI.DTOs.Person.PersonsGeneral.Responses;
using AnimalShelter_WebAPI.DTOs.Person.Responses;
using AnimalShelter_WebAPI.DTOs.Requests;
using AnimalShelter_WebAPI.DTOs.Role.Responses;
using AnimalShelter_WebAPI.Exceptions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;

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



        public PageResponse<GeneralPersonResponse> GetPersons(GetPersonsRequest getPersonsRequest)
        {
            IQueryable<Person> basePersons = _context.Person
                 .Include(req => req.GrantedRoles).ThenInclude(req => req.Role);
                // .ToList();

            if (!string.IsNullOrEmpty(getPersonsRequest.SortBy))
            {
                var columnsSelector = new Dictionary<string, Expression<Func<Person, object>>>
                    (StringComparer.InvariantCultureIgnoreCase)
                {
                    { nameof(Person.FirstName), r => r.FirstName},
                    { nameof(Person.LastName), r => r.LastName},
                    { nameof(Person.Sex), r => r.Sex}

                };
                var selectedColumn = columnsSelector[getPersonsRequest.SortBy];

                basePersons = getPersonsRequest.SortDirection == SortDirection.ASC
                    ? basePersons.OrderBy(selectedColumn)
                    : basePersons.OrderByDescending(selectedColumn);
            }

            var returnPersons = basePersons
               .Skip(getPersonsRequest.pageSize * (getPersonsRequest.pageNumber - 1))
               .Take(getPersonsRequest.pageSize)
               .ToList();

            var totalItemsCount = basePersons.Count();

            var personsList = _mapper.Map<IEnumerable<GeneralPersonResponse>>(returnPersons);
            var result = new PageResponse<GeneralPersonResponse>(personsList, totalItemsCount, getPersonsRequest.pageSize, getPersonsRequest.pageNumber);
            return result;

          
        }

        public PersonResponse GetPerson(int Id)
        {
            var person = _context.Person.Where(a => a.Id == Id)
                .Include(req => req.GrantedRoles).ThenInclude(req => req.Role)
                 .Include(req => req.Employee).ThenInclude(req => req.Vet).ThenInclude(req => req.Vet_Specialties).ThenInclude(req => req.Specialty)
                 .FirstOrDefault();

            if (person is null)
                throw new NotFoundException("PERSON_NOT_FOUND");

            return _mapper.Map<PersonResponse>(person);
        }

        public IEnumerable<RoleResponse> GetRoles()
        {
            var roles = _context.Role
               .ToList();
            return _mapper.Map<IEnumerable<RoleResponse>>(roles);
        }


        //Adopter to osoba, ale bez hasła  - bedzie tworzone poprzez createperson

        public Person CreateAdopter(CreateAdopterRequest createAdopterRequest)
        {
            var adopter = _mapper.Map<Person>(createAdopterRequest);
            _context.Person.Add(adopter);
            _context.SaveChanges();

            return adopter;
        }


        public int RegisterPerson(RegisterPersonRequest registerPersonRequest)
        {
            using var transaction = _context.Database.BeginTransaction(); //dane nie zapiszą się, jeśli którykolwiek element będzie niepoprawny

            var newPerson = new Person()
            {
                EmailAddress = registerPersonRequest.EmailAddress,
                FirstName = registerPersonRequest.FirstName,
                LastName = registerPersonRequest.LastName,
                PESEL = registerPersonRequest.PESEL,
                Sex = registerPersonRequest.Sex,
                PhoneNumber = registerPersonRequest.PhoneNumber,
                Address = registerPersonRequest.Address
            };

            if (registerPersonRequest.Password is not null)
            {
                var hashedPassword = _passwordHasher.HashPassword(newPerson, registerPersonRequest.Password);
                newPerson.Password = hashedPassword;
            }

            //adding person 
            _context.Person.Add(newPerson);
            _context.SaveChanges();

            if (registerPersonRequest.RoleId is not null)
            {

                //adding roles to newly created person
                var newGrantedRole = new GrantedRole()
                {
                    PersonId = newPerson.Id,
                    RoleId = (int)registerPersonRequest.RoleId
                };


                _context.GrantedRole.Add(newGrantedRole);

                _context.SaveChanges();

                CreateEntitiesBasedOnPersonRoles(newPerson, newGrantedRole, registerPersonRequest);
                }

            transaction.Commit();
            return newPerson.Id;

        }

        private void CreateEntitiesBasedOnPersonRoles(Person newPerson, GrantedRole newGrantedRole, RegisterPersonRequest registerPersonRequest)
        {

            switch (newGrantedRole.RoleId)
            {
                case 1: //Volunteer
                    var newVolunteer = _mapper.Map<Volunteer>(registerPersonRequest);
                    newVolunteer.Id = newPerson.Id;
                    _context.Volunteer.Add(newVolunteer);
                    _context.SaveChanges();
                    break;
                case 5: //Vet

                  
                    var newEmp = _mapper.Map<Employee>(registerPersonRequest);
                    newEmp.Id = newPerson.Id;
                    newEmp.IsRoleActive = false;
                    _context.Employee.Add(newEmp);

                    var newVet = _mapper.Map<Vet>(registerPersonRequest);
                    newVet.Id = newPerson.Id;
                    _context.Vet.Add(newVet);

                    

                  
                    /*
                    foreach (var specialty in registerPersonRequest.VetSpecialties)
                    {
                        var specialtyExistenceCheck = _context.Specialty.FirstOrDefault(p => p.Id == specialty.SpecialtyId);
                        if (specialtyExistenceCheck is null)
                            throw new BadRequestException("SPECIALTY_NOT_EXISTS");

                        var specialtyAddedExists = _context.Vet_Specialty.FirstOrDefault(vs => vs.SpecialtyId == specialty.SpecialtyId && vs.VetId == newPerson.Id);
                        if (specialtyAddedExists is not null)
                            specialtyAddedExists.ObtainingDate = specialty.ObtainingDate;
                        else
                        {
                            var vet_specialty = new Vet_Specialty()
                            {
                                VetId = newPerson.Id,
                                SpecialtyId = specialty.SpecialtyId,
                                ObtainingDate = specialty.ObtainingDate
                            };

                            _context.Vet_Specialty.Add(vet_specialty);
                        }
                    } */

                    _context.SaveChanges();
                    break;
                case 2: //Emp
                    var newEmpl = _mapper.Map<Employee>(registerPersonRequest);
                    newEmpl.Id = newPerson.Id;
                    _context.Employee.Add(newEmpl);

                    _context.SaveChanges();
                    break;

                default:
                    break;
            }
        }

        //login
        public TokenResponse GenerateJwt(LoginRequest request)
        {

            var person = _context.Person
                .Include(p => p.GrantedRoles)
                .FirstOrDefault(p => p.EmailAddress == request.EmailAddress);

            if (person is null)
            {
                throw new UnauthorizedException("WRONG_LOGIN_OR_PASSWORD");
            }

            var result = _passwordHasher.VerifyHashedPassword(person, person.Password, request.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                throw new UnauthorizedException("WRONG_LOGIN_OR_PASSWORD");
            }

            var roles = person.GrantedRoles;
            Console.WriteLine(roles);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, person.Id.ToString()),
                new Claim("firstName", $"{person.FirstName}"),
                new Claim("lastName", $"{person.LastName}"),

                new Claim("id", $"{person.Id}")
            };


            IList<string> rolesArray = new List<string>();
            //adding clams for Roles 
                foreach (var role in person.GrantedRoles)
            {
                var grantedRole = _context.GrantedRole
                .Include(p => p.Role)
                .FirstOrDefault( p => p.RoleId == role.RoleId);
                rolesArray.Add(grantedRole.Role.Name);


                claims.Add(new Claim(ClaimTypes.Role, grantedRole.Role.Name));
              //  claims.Add(new Claim("role", $"{grantedRole.Role.Name}"));

            }
            string rolesJson = JsonConvert.SerializeObject(rolesArray);
            claims.Add(new Claim("roles", rolesJson, JsonClaimValueTypes.JsonArray));


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


            return new TokenResponse { AccessToken = tokenHandler.WriteToken(token), TokenType = "Bearer" };

        }

        public void EditPerson(int id, EditPersonRequest editPersonRequest)
        {
            var preson = _context.Person.Where(a => a.Id == id)

             .FirstOrDefault();

            if (preson is null)
                throw new NotFoundException("PERSON_NOT_FOUND");


            preson.FirstName = editPersonRequest.FirstName;
            preson.LastName = editPersonRequest.LastName;
            preson.PESEL = editPersonRequest.PESEL;
            preson.PhoneNumber = editPersonRequest.PhoneNumber;
            preson.Address = editPersonRequest.Address;
            preson.Sex = editPersonRequest.Sex;


            _context.SaveChanges();
        }
    }
}
