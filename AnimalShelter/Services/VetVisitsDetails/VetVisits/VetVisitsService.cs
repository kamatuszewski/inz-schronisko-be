using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.VetVisitDetails;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Services.VetVisitsDetails
{
    public class VetVisitsService : IVetVisitsService
    {
        private readonly ShelterDbContext _context;
        private readonly IMapper _mapper;
        public VetVisitsService(ShelterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public VetVisit CreateVetVisit (CreateVetVisitRequest createVetVisitRequest)
        {
            var vetVisit = _mapper.Map<VetVisit>(createVetVisitRequest);
            _context.VetVisit.Add(vetVisit);
            _context.SaveChanges();
            return vetVisit;
        }
    }
}
