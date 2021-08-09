using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.VetVisitDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Services.VetVisitsDetails
{
    public interface IVetVisitsService
    {
        public VetVisit CreateVetVisit(CreateVetVisitRequest createVetVisitRequest);

    }
}
