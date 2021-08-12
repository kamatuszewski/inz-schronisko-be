using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.VetVisitDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Services.VetVisitsDetails
{
    public interface ITreatmentsService
    {
        public IEnumerable<TreatmentsResponse> GetTreatments();
        public Treatment CreateTreatment(CreateTreatmentRequest createTreatmentRequest);

        public void RemoveTreatment(int id);
    }
}
