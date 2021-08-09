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
    public class TreatmentsService : ITreatmentsService
    {
        private readonly ShelterDbContext _context;
        private readonly IMapper _mapper;
        public TreatmentsService(ShelterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Treatment CreateTreatment(CreateTreatmentRequest createTreatmentRequest)
        {
            var treatment = _mapper.Map<Treatment>(createTreatmentRequest);
            _context.Treatment.Add(treatment);
            _context.SaveChanges();
            return treatment;
        }

        public IEnumerable<TreatmentsResponse> GetTreatments()
        {
            var treatments = _context.Treatment
                .ToList();
            return _mapper.Map<IEnumerable<TreatmentsResponse>>(treatments);
        }
    }
}
