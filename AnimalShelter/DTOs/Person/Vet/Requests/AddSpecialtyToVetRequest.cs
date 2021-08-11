﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Person.Vet.Requests
{
    public class AddSpecialtyToVetRequest
    {
        [Required]
        public int SpecialtyId { get; set; }
        [Required]
        public DateTime ObtainingDate { get; set; }
    }
}
