using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Controllers
{
    [Route("api/[controller]")] //rownoznaczne z ("api/students")
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        [HttpGet]
        public string GetAnimals()
        {
            return "1, 2, 3";
        }
    }
}
