﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class Status:BaseEntity
    {
        public string Name { get; set; }
//        public string Description { get; set; }


        public virtual ICollection<Animal> Animals { get; set; }
    }
}
