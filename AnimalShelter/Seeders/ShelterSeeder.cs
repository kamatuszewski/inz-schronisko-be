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

                if (!_dbContext.Species.Any())
                {
                    var species = GetSpecies();
                    _dbContext.Species.AddRange(species);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Specialty.Any())
                {
                    var specialties = GetSpecialties();
                    _dbContext.Specialty.AddRange(specialties);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Treatment.Any())
                {
                    var treatments = GetTreatments();
                    _dbContext.Treatment.AddRange(treatments);
                    _dbContext.SaveChanges();
                }


                if (!_dbContext.Medicine.Any())
                {
                    var medicines = GetMedicines();
                    _dbContext.Medicine.AddRange(medicines);
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


        private IEnumerable<Specialty> GetSpecialties()
        {
            var specialties = new List<Specialty>()
            {
                new Specialty()
                {
                   Name = "Internista"
                },

                new Specialty()
                {
                   Name = "Ortopeda"
                },

                new Specialty()
                {
                   Name = "Nefrolog"
                },

                new Specialty()
                {
                   Name = "Behawiorysta"
                },
                new Specialty()
                {
                   Name = "Dermatolog"
                },
                new Specialty()
                {
                   Name = "Kardiolog"
                },
                new Specialty()
                {
                   Name = "Okulista"
                },
                new Specialty()
                {
                   Name = "Stomatolog"
                },
                new Specialty()
                {
                   Name = "Neurolog"
                },
                new Specialty()
                {
                   Name = "Onkolog"
                },
                new Specialty()
                {
                   Name = "Pulmunolog"
                }
            };
            return specialties;
        }


        private IEnumerable<Treatment> GetTreatments()
        {
            var treatments = new List<Treatment>()
            {
                new Treatment()
                {
                   Name = "Sterylizacja / kastracja"
                },

                new Treatment()
                {
                   Name = "Chirurgiczne zespalanie złamania/złamań kości"
                },

                new Treatment()
                {
                   Name = "Zabieg na stawach"
                },

                new Treatment()
                {
                   Name = "Zabieg na kręgsłupie"
                },
                new Treatment()
                {
                   Name = "Chirurgiczne usuwanie guza/guzów"
                },
                new Treatment()
                {
                   Name = "Zabieg okulistyczne"
                },
                new Treatment()
                {
                   Name = "Chirurgiczne leczenie przepukliny"
                },
                new Treatment()
                {
                   Name = "Zabieg związany z chorobami układu moczowego"
                },
                new Treatment()
                {
                   Name = "USG"
                },
                new Treatment()
                {
                   Name = "RTG"
                },
                new Treatment()
                {
                   Name = "Gastroskopia"
                },
                 new Treatment()
                {
                   Name = "Tomografia komupterowa"
                }
            };
            return treatments;
        }


        private IEnumerable<Medicine> GetMedicines()
        {
            var medicines = new List<Medicine>()
            {
                new Medicine()
                {
                   Name = "Actikor 5 mg tabletki dla psów"
                },

                new Medicine()
                {
                   Name = "Amflee 50 mg roztwór"
                },

                new Medicine()
                {
                   Name = "Amotaks Wet. Tabletki 200 mg"
                },

                new Medicine()
                {
                   Name = "Bexepril 8 blistrów 14 tabl."
                },
                new Medicine()
                {
                   Name = "Biocan puppy"
                },
                new Medicine()
                {
                   Name = "Zabieg okulistyczne"
                },
                new Medicine()
                {
                   Name = "Chirurgiczne leczenie przepukliny"
                },
                new Medicine()
                {
                   Name = "Canidryl 100 mg tabletki"
                },
                new Medicine()
                {
                   Name = "Carthrophen Vet 100 mg/ml"
                },
                new Medicine()
                {
                   Name = "Ditrivet 120, (100 mg + 20 mg)/tabletki"
                },
                new Medicine()
                {
                   Name = "Dolocarp flavour, 50 mg"
                },
                 new Medicine()
                {
                   Name = "Effipro 402 mg roztwór"
                },
                new Medicine()
                {
                   Name = "Floxabactin 50 mg"
                },
                new Medicine()
                {
                   Name = "Floxal żel 5ml"
                },
                new Medicine()
                {
                   Name = "Kefavet vet. 500 mg"
                },
                new Medicine()
                {
                   Name = "Nelio 2,5 mg tabletki"
                },
                 new Medicine()
                {
                   Name = "Pestigon 50 mg roztwór do nakrapiania"
                },
                  new Medicine()
                {
                   Name = "Rimadyl Palatable Tablets 20 mg"
                },
                new Medicine()
                {
                   Name = "Synergal tabl. 50 mg (40 + 10) mg/tabletkę"
                },
                 new Medicine()
                {
                   Name = "Vetaprofen 100ml"
                }
            };
            return medicines;
        }

    }
}
