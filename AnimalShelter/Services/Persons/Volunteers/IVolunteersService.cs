using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs;
using AnimalShelter_WebAPI.DTOs.Person;
using AnimalShelter_WebAPI.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Services.Persons.Volunteers
{
    public interface IVolunteersService
    {
        public PageResponse<GeneralVolunteerResponse> GetVolunteers(GetVolunteersRequest getVolunteersRequest);
        public DetailedVolunteerResponse GetVolunteer(int id);
    }
}
