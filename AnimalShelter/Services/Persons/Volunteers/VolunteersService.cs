using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs;
using AnimalShelter_WebAPI.DTOs.Person;
using AnimalShelter_WebAPI.DTOs.Requests;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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


       public PageResponse<GeneralVolunteerResponse> GetVolunteers(GetVolunteersRequest getVolunteersRequest)
        {
            IQueryable<Volunteer> baseVolunteers = _context.Volunteer
                .Include(req => req.Person);

            if (!string.IsNullOrEmpty(getVolunteersRequest.SortBy))
            {
                var columnsSelector = new Dictionary<string, Expression<Func<Volunteer, object>>>
                 (StringComparer.InvariantCultureIgnoreCase)
                {
                    { nameof(Volunteer.Person.FirstName), r => r.Person.FirstName},
                    { nameof(Volunteer.Person.LastName), r => r.Person.LastName},
                    { nameof(Volunteer.Person.Sex), r => r.Person.Sex},
                    { nameof(Volunteer.JoiningDate), r => r.JoiningDate}

                };

                var selectedColumn = columnsSelector[getVolunteersRequest.SortBy];

                baseVolunteers = getVolunteersRequest.SortDirection == SortDirection.ASC
                    ? baseVolunteers.OrderBy(selectedColumn)
                    : baseVolunteers.OrderByDescending(selectedColumn);
            }
            var volunteers = baseVolunteers.ToList();


            var returnVolunteers = baseVolunteers
               .Skip(getVolunteersRequest.pageSize * (getVolunteersRequest.pageNumber - 1))
               .Take(getVolunteersRequest.pageSize)
               .ToList();

            var totalItemsCount = baseVolunteers.Count();

            var volunteersList = _mapper.Map<IEnumerable<GeneralVolunteerResponse>>(returnVolunteers);
            var result = new PageResponse<GeneralVolunteerResponse>(volunteersList, totalItemsCount, getVolunteersRequest.pageSize, getVolunteersRequest.pageNumber);
            return result;

         //    return _mapper.Map<IEnumerable<GeneralVolunteerResponse>>(volunteers);
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
