using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Person.Vet.Responses
{
    public class ObtainedSpecialtyResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ObtainingDate { get; set; }
    }
}
