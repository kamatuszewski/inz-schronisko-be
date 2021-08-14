using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.VetVisitDetails;
using AnimalShelter_WebAPI.DTOs.VetVisitDetails.VetVisits.Requests;
using AnimalShelter_WebAPI.DTOs.VetVisitDetails.VetVisits.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Services.VetVisitsDetails
{
    public interface IVetVisitsService
    {
        public VetVisitResponse GetVetVisit(int id);
        public VetVisit CreateVetVisit(CreateVetVisitRequest createVetVisitRequest);
        public void UpdateVetVisit(int id, UpdateVetVisitRequest updateVetVisitRequest);
        public void RemoveVetVisit(int id);
      //  public void AddDetailsToVetVisit(int visitId, AddDetailsToVetVisitRequest addDetailsToVetVisitRequest);
        public void RemoveMedicineFromVisit(int VetVisitId, int MedicineId);
        public void RemoveTreatmentFromVisit(int VetVisitId, int TreatmentId);
        
    }
}
