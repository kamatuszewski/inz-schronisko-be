﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.VetVisit.Responses
{
    public class GeneralVetVisitResponse
    {
         public int Id { get; set; }
        public DateTime VisitDateTime { get; set; }
        public string Description { get; set; }
    }
}
