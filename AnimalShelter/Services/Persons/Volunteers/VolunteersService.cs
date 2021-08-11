using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.Person;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Services.Persons.Volunteers
{
    public class VolunteersService : IVolunteersService
    {

        private readonly ShelterDbContext _context;
        private readonly IMapper _mapper;
        public VolunteersService(ShelterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


       public IEnumerable<GeneralVolunteerResponse> GetVolunteers()
        {
            var volunteers = _context.Volunteer
                .Include(req => req.Person)
                .ToList();
            return _mapper.Map<IEnumerable<GeneralVolunteerResponse>>(volunteers);
        }

        public DetailedVolunteerResponse GetVolunteer(int id)
        {
            var volunteer = _context.Volunteer.Where(a => a.Id == id)
                 .Include(req => req.Person)
                 .FirstOrDefault();
            return _mapper.Map<DetailedVolunteerResponse>(volunteer);
        }

    }
}
