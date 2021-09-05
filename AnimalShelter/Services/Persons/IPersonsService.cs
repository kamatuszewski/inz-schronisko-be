
using AnimalShelter.DTOs;
using AnimalShelter.DTOs.Responses;
using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs;
using AnimalShelter_WebAPI.DTOs.Person.PersonsGeneral.Responses;
using AnimalShelter_WebAPI.DTOs.Person.Responses;
using AnimalShelter_WebAPI.DTOs.Requests;
using AnimalShelter_WebAPI.DTOs.Role.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AnimalShelter.Services
{
    public interface IPersonsService
    {

        public PersonResponse GetPerson(int id);
        public PageResponse<GeneralPersonResponse> GetPersons(GetPersonsRequest getPersonsRequest);
        public IEnumerable<RoleResponse> GetRoles();
        public int RegisterPerson(RegisterPersonRequest registerPersonRequest);
        public Person CreateAdopter(CreateAdopterRequest createAdopterRequest);
        TokenResponse GenerateJwt(LoginRequest request);
        public void EditPerson(int id, EditPersonRequest editPersonRequest);
    }
}


