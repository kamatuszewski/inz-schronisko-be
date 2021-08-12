using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.Adoption.Responses;
using AnimalShelter_WebAPI.DTOs.Animal.Responses;
using AnimalShelter_WebAPI.DTOs.Requests;
using AnimalShelter_WebAPI.Exceptions;
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

        public Adoption CreateAdoption(CreateAdoptionRequest createAdoptionRequest)
        {
            var adoption = _mapper.Map<Adoption>(createAdoptionRequest);
            _context.Adoption.Add(adoption);
            _context.SaveChanges();

            var animal = _context.Animal.Where(a => a.Id == createAdoptionRequest.AnimalId)
            .FirstOrDefault();

            animal.StatusId = _context.Status.Where(a => a.Name == "ADOPTED").FirstOrDefault().Id;
            _context.SaveChanges();
            return adoption;
        }

        public void RemoveAdoption(int id)
        {
            var adoption = _context.Adoption.Where(a => a.Id == id)
               .FirstOrDefault();
            if (adoption is null) throw new NotFoundException("ADOPTION_NOT_FOUND");

            _context.Adoption.Remove(adoption);
            _context.SaveChanges();

        }

    }
}
