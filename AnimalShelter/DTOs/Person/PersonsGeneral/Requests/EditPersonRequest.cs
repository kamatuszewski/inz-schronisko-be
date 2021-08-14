using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Requests
{
    public class EditPersonRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PESEL { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }


        // public string EmailAddress { get; set; }
        //public string Password { get; set; }
    }
}
