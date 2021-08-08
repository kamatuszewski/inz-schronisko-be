using AnimalShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Services
{
    public class DictionariesService
    {
        private readonly ShelterDbContext _context;
        public DictionariesService (ShelterDbContext context)
        {
            _context = context;
        }

    }
}
