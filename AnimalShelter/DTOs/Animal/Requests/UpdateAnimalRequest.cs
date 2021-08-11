using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Animal.Requests
{
    public class UpdateAnimalRequest
    {

        public string Name { get; set; }
        //    [Required]
        //    public DateTime BirthDate { get; set; }
        //   [Required]
        //    public string Sex { get; set; }
        [Required]
        public string FoundPlace { get; set; }
        [Required]
        public int StatusId { get; set; }
    }
}
