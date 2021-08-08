using AnimalShelter_WebAPI.DTOs.VetVisitDetails;
using AnimalShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Services.VetVisitsDetails
{
    public interface IMedicinesService
    {
        public IEnumerable<MedicinesResponse> GetMedicines();
        public Medicine CreateMedicine(CreateMedicineRequest createMedicineRequest);

    }
}
