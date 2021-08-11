using AnimalShelter_WebAPI.DTOs.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Services.Persons.Volunteers
{
    public interface IVolunteersService
    {
        public IEnumerable<GeneralVolunteerResponse> GetVolunteers();
        public DetailedVolunteerResponse GetVolunteer(int id);
    }
}
