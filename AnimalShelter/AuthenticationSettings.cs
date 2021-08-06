using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI
{
    public class AuthenticationSettings
    {
        public string SecretKey { get; set; }
        public int JwtExpireHours { get; set; }
        public string JwtIssuer { get; set; }
    }
}
