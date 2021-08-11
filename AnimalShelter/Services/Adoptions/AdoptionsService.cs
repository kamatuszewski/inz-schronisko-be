using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.Adoption.Responses;
using AnimalShelter_WebAPI.DTOs.Animal.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Services.Adoptions
{
    public class AdoptionsService : IAdoptionsService
    {

        private readonly ShelterDbContext _context;
        private readonly IMapper _mapper;
        public AdoptionsService(ShelterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<DetailedAdoptionResponse> GetAdoptions()
        {
            var adoptions = _context.Adoption
                .Include(req => req.Adopter)
                .Include(req => req.Employee).ThenInclude(req => req.Person)
                .Include(req => req.Animal).ThenInclude(req => req.Species)
                .Include(req => req.Animal).ThenInclude(req => req.Status)
                .ToList();
            return _mapper.Map<IEnumerable<DetailedAdoptionResponse>>(adoptions);
        }

    }
}
