using AnimalShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Seeders
{
    public class TestDataSeeder
    {
        private readonly ShelterDbContext _dbContext;

        public TestDataSeeder(ShelterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SeedTestData()
        {
            if (_dbContext.Database.CanConnect())
            {
                
                if (!_dbContext.Animal.Any())
                {
                    var animals = GetAnimals();
                    _dbContext.Animal.AddRange(animals);
                    _dbContext.SaveChanges();
                }

             
               if (!_dbContext.Person.Any())
                {
                    var persons = GetPersons();
                    _dbContext.Person.AddRange(persons);
                    _dbContext.SaveChanges();
                }


                if (!_dbContext.Employee.Any())
                {
                    var employees = GetEmployees();
                    _dbContext.Employee.AddRange(employees);
                    _dbContext.SaveChanges();
                }


                if (!_dbContext.AdoptionOfficeWorker.Any())
                {
                    var aoWorkers = GetAOWorker();
                    _dbContext.AdoptionOfficeWorker.AddRange(aoWorkers);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Adoption.Any())
                {
                    var adoptions = GetAdoptions();
                    _dbContext.Adoption.AddRange(adoptions);
                    _dbContext.SaveChanges();
                }

            }
        }

        //Roles
        private IEnumerable<Animal> GetAnimals()
        {
            var animals = new List<Animal>()
            {
                new Animal()
                {
                    ChipNumber = 1,
                    Name = "Zosia",
                    BirthDate = new DateTime(2020, 10, 10, 0, 0, 0),
                    Sex = "F",
                    FoundDate = new DateTime(2020, 10, 10, 0, 0, 0),
                    FoundPlace = "Warszawa",
                    StatusId = 2,
                    SpeciesId = 1
                },

                new Animal()
                {
                    ChipNumber = 2,
                    Name = "Puszek",
                    BirthDate = new DateTime(2020, 10, 10, 0, 0, 0),
                    Sex = "M",
                    FoundDate = new DateTime(2020, 10, 10, 0, 0, 0),
                    FoundPlace = "Ilawa",
                    StatusId = 3,
                    SpeciesId = 2
                },

                 new Animal()
                {
                    ChipNumber = 3,
                    BirthDate = new DateTime(2008, 10, 10, 0, 0, 0),
                    Sex = "M",
                    FoundDate = new DateTime(2020, 10, 10, 0, 0, 0),
                    FoundPlace = "Kokos",
                    StatusId = 3,
                    SpeciesId = 4
                }


            };
            return animals;
        }

        private IEnumerable<Person> GetPersons()
        {
            var persons = new List<Person>()
            {
                new Person()
                {
                    FirstName = "Anna",
                    LastName = "Marianowa",
                    PESEL = "111111111",
                    Sex = "F",
                    Address = "Warszawska 7/11, Warszawa",
                    PhoneNumber = "111111111",
                    EmailAddress = "m@op.pl"
                },

                new Person()
                {
                    FirstName = "Krzysztof",
                    LastName = "Mazurek",
                    PESEL = "22222222222",
                    Sex = "M",
                    Address = "Wakowiocza 7/11, Warszawa",
                    PhoneNumber = "222222222",
                    EmailAddress = "km@op.pl"
                },

                 new Person()
                {
                    FirstName = "Michal",
                    LastName = "Michalczyk",
                    PESEL = "22222233222",
                    Sex = "M",
                    Address = "Wakowiocza 7/20, Warszawa",
                    PhoneNumber = "222211222",
                    EmailAddress = "k2m@op.pl"
                },

                   new Person()
                {
                    FirstName = "Magdalena",
                    LastName = "Krzak",
                    PESEL = "22201233222",
                    Sex = "F",
                    Address = "Kasprzaka 9/20, Warszawa",
                    PhoneNumber = "999888777",
                    EmailAddress = "mkk@op.pl"
                },

                    new Person()
                {
                    FirstName = "Karolina",
                    LastName = "Kurzak",
                    PESEL = "22206633222",
                    Sex = "F",
                    Address = "Karolka 9/20, Warszawa",
                    PhoneNumber = "990088777",
                    EmailAddress = "karolka@op.pl"
                }
            };
            return persons;
        }

        private IEnumerable<Employee> GetEmployees()
        {
            var employees = new List<Employee>()
            {
                new Employee()
                {
                   Id = 1,
                   HireDate = new DateTime(2010, 10, 10, 0, 0, 0),
                   Salary = 5000
                },

                new Employee()
                {
                   Id = 2,
                   HireDate = new DateTime(2015, 10, 10, 0, 0, 0),
                   Salary = 3000
                }
            };
            return employees;
        }


        private IEnumerable<AdoptionOfficeWorker> GetAOWorker()
        {
            var aoWorkers = new List<AdoptionOfficeWorker>()
            {
                new AdoptionOfficeWorker()
                {
                    Id = 1,
                   AssignedSpeciesId = 1
                }                
            };
            return aoWorkers;
        }

        private IEnumerable<Adoption> GetAdoptions()
        {
            var adoptions = new List<Adoption>()
            {
                new Adoption()
                {
                    AdoptionDate = new DateTime(2021, 10, 10, 0, 0, 0),
                    Notes = "brak",
                    IsItOwnerPickUp = true,
                    AnimalId = 1,
                    AdopterId = 2,
                    EmployeeId = 1
                },

            };
            return adoptions;
        }

    }
}
