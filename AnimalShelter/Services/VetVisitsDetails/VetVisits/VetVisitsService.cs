using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.VetVisitDetails;
using AnimalShelter_WebAPI.DTOs.VetVisitDetails.VetVisits.Requests;
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


        public VetVisitResponse GetVetVisit(int visitId)
        {

            var vet_visit = _context.VetVisit
                .Include(req => req.PerformedTreatments).ThenInclude(req => req.Treatment)
                .Include(req => req.PrescribedMedicines).ThenInclude(req => req.Medicine)
                .Include(req => req.Vet).ThenInclude(req => req.Employee).ThenInclude(req => req.Person)
                .Include(req => req.Vet).ThenInclude(req => req.Vet_Specialties).ThenInclude(req => req.Specialty)
                .Include(req => req.Animal).ThenInclude(req => req.Species)
                .Include(req => req.Animal).ThenInclude(req => req.Status)
                .FirstOrDefault(p => p.Id == visitId);

            if (vet_visit is null)
                throw new BadRequestException("VISIT_NOT_EXISTS");

            return _mapper.Map<VetVisitResponse>(vet_visit);


        }
        public VetVisit CreateVetVisit (CreateVetVisitRequest createVetVisitRequest)
        {
            using var transaction = _context.Database.BeginTransaction(); //dane nie zapiszą się, jeśli którykolwiek element będzie niepoprawny

            var vet = _context.Vet.FirstOrDefault(p => p.Id == createVetVisitRequest.VetId);
            if (vet is null)
                throw new NotFoundException("VET_NOT_FOUND");

            var animal = _context.Animal.FirstOrDefault(p => p.Id == createVetVisitRequest.AnimalId);
            if (animal is null)
                throw new NotFoundException("ANIMAL_NOT_FOUND");


            var newVetVisit = new VetVisit
            {
                AnimalId = createVetVisitRequest.AnimalId,
                VetId = createVetVisitRequest.VetId,
                VisitDate = createVetVisitRequest.VisitDate,
                Description = createVetVisitRequest.Description
            };
                
                                
    
            _context.VetVisit.Add(newVetVisit);
            _context.SaveChanges();

            AddDetailsToVetVisit(newVetVisit.Id, createVetVisitRequest.PrescribedMedicines, createVetVisitRequest.PerformedTreatments);

            transaction.Commit();
            return newVetVisit;
        }

        public void UpdateVetVisit (int id, UpdateVetVisitRequest updateVetVisitRequest)
        {
            using var transaction = _context.Database.BeginTransaction(); //dane nie zapiszą się, jeśli którykolwiek element będzie niepoprawny

            var vetVisit = _context.VetVisit.Where(a => a.Id == id)
             .FirstOrDefault();

            if (vetVisit is null)
                throw new NotFoundException("VETVISIT_NOT_FOUND");

            vetVisit.Description = updateVetVisitRequest.Description;
            _context.SaveChanges();

            var oldMedicines =_context.PrescribedMedicine.Where(a => a.VisitId == id).ToList();
            _context.PrescribedMedicine.RemoveRange(oldMedicines);

            var oldTreatments = _context.PerformedTreatment.Where(a => a.VisitId == id).ToList();
            _context.PerformedTreatment.RemoveRange(oldTreatments);

            _context.SaveChanges();

            AddDetailsToVetVisit(id, updateVetVisitRequest.PrescribedMedicines, updateVetVisitRequest.PerformedTreatments);
            transaction.Commit();

          


        }
        public void RemoveVetVisit (int id)
        {
            var vetVisit = _context.VetVisit.Where(a => a.Id == id)
               .FirstOrDefault();

            if (vetVisit is null)
                throw new NotFoundException("VETVISIT_NOT_FOUND");

            _context.VetVisit.Remove(vetVisit);
            _context.SaveChanges();

        }

        public void AddDetailsToVetVisit(int id, IEnumerable<PrescribeMedicineRequest> PrescribedMedicines, IEnumerable<AddPerformedTreatmentRequest> PerformedTreatments) {

            var vet_visit = _context.VetVisit.FirstOrDefault(p => p.Id == id);
            if (vet_visit is null)
                throw new BadRequestException("VISIT_NOT_EXISTS");


       
            foreach (var medicine in PrescribedMedicines) {
                var medicineExistenceCheck = _context.Medicine.FirstOrDefault(p => p.Id == medicine.Id);
                if (medicineExistenceCheck is null)
                    throw new BadRequestException("MEDICINE_NOT_EXISTS");

                var prescribedMedicine = _context.PrescribedMedicine.FirstOrDefault(gr => gr.VisitId == id && gr.MedicineId == medicine.Id);
                if (prescribedMedicine is not null)
                    prescribedMedicine.Amount = medicine.Amount;
                else 
                {
                    prescribedMedicine = new PrescribedMedicine()
                    {
                        MedicineId = medicine.Id,
                        VisitId = id,
                        Amount = medicine.Amount
                    };
                    _context.PrescribedMedicine.Add(prescribedMedicine);
                    _context.SaveChanges();
                }
                
               
            }

            foreach (var treatment in PerformedTreatments)
            {
                var treatmentExistenceCheck = _context.Treatment.FirstOrDefault(p => p.Id == treatment.Id);
                if (treatmentExistenceCheck is null)
                    throw new BadRequestException("TREATMENT_NOT_EXISTS");

                var performedTreatment = _context.PerformedTreatment.FirstOrDefault(gr => gr.VisitId == id && gr.TreatmentId == treatment.Id);
                if (performedTreatment is null) //w przeciwnym razie nic nie robimy, juz istnieje takie polaczenie
                { 
                    performedTreatment = new PerformedTreatment()
                    {
                        TreatmentId = treatment.Id,
                        VisitId = id
                    };
                    _context.PerformedTreatment.Add(performedTreatment);
                    _context.SaveChanges();
                }
            }


        }

        public void RemoveMedicineFromVisit (int VetVisitId, int MedicineId)
        {
            var vetVisit = _context.VetVisit.FirstOrDefault(p => p.Id == VetVisitId);
            if (vetVisit is null)
                throw new BadRequestException("VETVISIT_NOT_EXISTS");

            var medicine = _context.Medicine.FirstOrDefault(r => r.Id == MedicineId);
            if (medicine is null)
                throw new BadRequestException("MEDICINE_NOT_EXISTS");

            var prescribedMedicine = _context.PrescribedMedicine.FirstOrDefault(gr => gr.VisitId == VetVisitId && gr.MedicineId == MedicineId);
            if (prescribedMedicine is null)
                throw new BadRequestException("NOT_PRESCRIBED");

            _context.PrescribedMedicine.Remove(prescribedMedicine);
            _context.SaveChanges();
        }

        public void RemoveTreatmentFromVisit(int VetVisitId, int TreatmentId)
        {
            var vetVisit = _context.VetVisit.FirstOrDefault(p => p.Id == VetVisitId);
            if (vetVisit is null)
                throw new BadRequestException("VETVISIT_NOT_EXISTS");

            var treatment = _context.Treatment.FirstOrDefault(r => r.Id == TreatmentId);
            if (treatment is null)
                throw new BadRequestException("TREATMENT_NOT_EXISTS");

            var performedTreatment = _context.PerformedTreatment.FirstOrDefault(gr => gr.VisitId == VetVisitId && gr.TreatmentId == TreatmentId);
            if (performedTreatment is null)
                throw new BadRequestException("NOT_PERFORMED");

            _context.PerformedTreatment.Remove(performedTreatment);
            _context.SaveChanges();
        }

        
    }
}
