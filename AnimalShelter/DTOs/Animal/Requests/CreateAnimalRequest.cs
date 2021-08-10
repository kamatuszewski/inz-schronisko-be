using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Requests
{
    public class CreateAnimalRequest
    {
     
        public string Name { get; set; }
        [Required]
        public int ChipNumber { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public DateTime FoundDate { get; set; }
        [Required]
        public string FoundPlace { get; set; }
    
        [Required]
        public int SpeciesId { get; set; }
        [Required]
        public int StatusId { get; set; }
    }
}
