﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class PerformedTreatment
    {
        public int IdTreatment { get; set; }
        public int IdVisit { get; set; }

        public virtual Treatment Treatment { get; set; }    
        public virtual VetVisit VetVisit { get; set; }    
    }
}

