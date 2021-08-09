﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class Vet_Specialty
    {
        public int VetId { get; set; }
        public int SpecialtyId { get; set; }
        public DateTime ObtainingDate { get; set; }

        public virtual Vet Vet { get; set; }    
        public virtual Specialty Specialty { get; set; }    
    }
}
