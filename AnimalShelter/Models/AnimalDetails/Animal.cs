﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class Animal:BaseEntity
    {

        public int ChipNumber { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
        public DateTime FoundDate { get; set; }

        [MaxLength(255)]
        public string FoundPlace { get; set; }
        public DateTime? DeathDate { get; set; }

        public int StatusId { get; set; }
        public int SpeciesId { get; set; }

        public virtual Species Species { get; set; }
        public virtual Status Status { get; set; }

        public virtual ICollection<VetVisit> VetVisits { get; set; }
        public virtual ICollection<Adoption> Adoptions { get; set; }
    }
}
