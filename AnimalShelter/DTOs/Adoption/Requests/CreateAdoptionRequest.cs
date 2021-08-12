using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Requests
{
    public class CreateAdoptionRequest
    {
       
        public string Notes { get; set; }
        public DateTime AdoptionDate { get; set; }
        public bool IsOwnerPickup { get; set; }
        public int AnimalId { get; set; }
        public int AdopterId { get; set; }
        public int EmployeeId { get; set; }

    }
}
