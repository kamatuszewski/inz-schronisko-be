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
    //    [FromHeader]
        public string Name { get; set; }
     //   [FromHeader]
        [Required]
        public int ChipNumber { get; set; }
    //    [FromHeader]
        [Required]
        public DateTime BirthDate { get; set; }
      //  [FromHeader]
        [Required]
        public string Sex { get; set; }
      //  [FromHeader]
        [Required]
        public DateTime FoundDate { get; set; }
       // [FromHeader]
        [Required]
        public string FoundPlace { get; set; }


     //   [FromHeader]
        [Required]
        public int SpeciesId { get; set; }
      //  [FromHeader]
        [Required]
        public int StatusId { get; set; }
    }
}
