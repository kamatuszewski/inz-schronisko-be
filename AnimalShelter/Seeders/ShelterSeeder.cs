using AnimalShelter.Models;
using Microsoft.EntityFrameworkCore;
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
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }

                //adding Roles
                if (!_dbContext.Role.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Role.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                //adding Animal Statuses
                if (!_dbContext.Status.Any())
                {
                    var statuses = GetStatuses();
                    _dbContext.Status.AddRange(statuses);
                    _dbContext.SaveChanges();
                }

                //adding Animal Species
                if (!_dbContext.Species.Any())
                {
                    var species = GetSpecies();
                    _dbContext.Species.AddRange(species);
                    _dbContext.SaveChanges();
                }
            }
        }

        //Roles
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "Volunteer"
                },
                new Role()
                {
                    Name = "Employee"
                },
                new Role()
                {
                    Name = "Director"
                },
                 new Role()
                {
                    Name = "Admin"
                },
                 new Role()
                 {
                     Name = "Vet"
                 }
            };

            return roles;

        }

        //Statuses
        private IEnumerable<Status> GetStatuses()
        {
            var statuses = new List<Status>()
            {
                new Status()
                {
                    Name = "QUARANTINE"
                },
                new Status()
                {
                    Name = "FOR_ADOPTION"
                },
                new Status()
                {
                    Name = "ADOPTED"
                },
                 new Status()
                {
                    Name = "DEAD"
                },
            };

            return statuses;

        }

        //Species
        private IEnumerable<Species> GetSpecies()
        {
            var species = new List<Species>()
            {
                new Species()
                {
                    Name = "DOG"
                },
                new Species()
                {
                    Name = "CAT"
                },
                new Species()
                {
                    Name = "BIRD"
                },
                new Species()
                {
                    Name = "MOUSE" 
                },
                new Species()
                {
                    Name = "HAMSTER" 
                },
                new Species()
                {
                    Name = "RAT"
                },
                new Species()
                {
                    Name = "RABBIT"
                },
                new Species()
                {
                    Name = "PIG"
                },
                new Species()
                {
                    Name = "OTHER"
                },
            };

            return species;

        }
    }
}
