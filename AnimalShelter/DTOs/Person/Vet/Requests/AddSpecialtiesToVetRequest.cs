using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Person.Vet.Requests
{
    public class AddSpecialtiesToVetRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime ObtainingDate { get; set; }
    }
}
