﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.VetVisitDetails.Medicines.Responses
{
    public class PrescribedMedicineResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
