using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Requests
{
    public class CreateAnimalRequest
    {
        [FromHeader]
        public string Name { get; set; }
        [FromHeader]
        public int ChipNumber { get; set; }
        [FromHeader]
        public DateTime BirthDate { get; set; }
        [FromHeader]
        public string Sex { get; set; }
        [FromHeader]
        public DateTime FoundDate { get; set; }
        [FromHeader]
        public string FoundPlace { get; set; }


        [FromHeader]
        public int IdSpecies { get; set; }
        [FromHeader]
        public int IdStatus { get; set; }
    }
}
