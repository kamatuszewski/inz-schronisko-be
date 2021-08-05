using AnimalShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI
{
    public class ShelterSeeder
    {
        private readonly ShelterDbContext _dbContext;

        public ShelterSeeder(ShelterDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Role.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Role.AddRange(roles);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "Wolontariusz"
                },
                new Role()
                {
                    Name = "Pracownik"
                },
                new Role()
                {
                    Name = "Dyrektor"
                },
                 new Role()
                {
                    Name = "Admin"
                },
            };

            return roles;

        }
    }
}
