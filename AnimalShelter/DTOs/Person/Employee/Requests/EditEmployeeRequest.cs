using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Requests
{
    public class EditEmployeeRequest
    {
        public int Salary { get; set; }
        public DateTime HireDate { get; set; }
        
    }
}
