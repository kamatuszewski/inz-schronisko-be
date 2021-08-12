using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.VetVisitDetails;
using AnimalShelter_WebAPI.DTOs.VetVisitDetails.VetVisits.Responses;
using AnimalShelter_WebAPI.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public VetVisitResponse GetVetVisit(int animalId, int visitId)
        {
            var vet_visit = _context.VetVisit.FirstOrDefault(p => p.Id == visitId);
            if (vet_visit is null)
                throw new BadRequestException("VISIT_NOT_EXISTS");

            vet_visit = _context.VetVisit
                .Include(req => req.PerformedTreatments).ThenInclude(req => req.Treatment)
                .Include(req => req.PrescribedMedicines).ThenInclude(req => req.Medicine)
                .Include(req => req.Vet).ThenInclude(req => req.Employee).ThenInclude(req => req.Person)
                .Include(req => req.Vet).ThenInclude(req => req.Vet_Specialties).ThenInclude(req => req.Specialty)
                .Include(req => req.Animal).ThenInclude(req => req.Species)
                .Include(req => req.Animal).ThenInclude(req => req.Status)
                .FirstOrDefault(p => p.Id == visitId && p.AnimalId == animalId);

            if (vet_visit is null)
                throw new BadRequestException("VISIT_ASSIGNED_TO_OTHER_ANIMAL");

            return _mapper.Map<VetVisitResponse>(vet_visit);


        }
    }
}
