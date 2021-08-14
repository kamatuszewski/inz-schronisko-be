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

                if (!_dbContext.Vet.Any())
                {
                    var vets = GetVets();
                    _dbContext.Vet.AddRange(vets);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.GrantedRole.Any())
                {
                    var grantedRole = GetGrantedRoles();
                    _dbContext.GrantedRole.AddRange(grantedRole);
                    _dbContext.SaveChanges();
                }

              

                if (!_dbContext.Vet_Specialty.Any())
                {
                    var vetSpescs = GetVetSpecs();
                    _dbContext.Vet_Specialty.AddRange(vetSpescs);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.VetVisit.Any())
                {
                    var vetvisits = GetVetVisits();
                    _dbContext.VetVisit.AddRange(vetvisits);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Medicine.Any())
                {
                    var medicines = GetMedicines();
                    _dbContext.Medicine.AddRange(medicines);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.PrescribedMedicine.Any())
                {
                    var prescribedMedicine = GetPrescribedMedicine();
                    _dbContext.PrescribedMedicine.AddRange(prescribedMedicine);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Treatment.Any())
                {
                    var treatment = GetTreatment();
                    _dbContext.Treatment.AddRange(treatment);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.PerformedTreatment.Any())
                {
                    var performedTreatment = GetPerformedTreatment();
                    _dbContext.PerformedTreatment.AddRange(performedTreatment);
                    _dbContext.SaveChanges();
                }

                //--

                if (!_dbContext.Adoption.Any())
                {
                    var adoptions = GetAdoptions();
                    _dbContext.Adoption.AddRange(adoptions);
                    _dbContext.SaveChanges();
                }

            }
        }

       
        private IEnumerable<Animal> GetAnimals()
        {
            var animals = new List<Animal>()
            {
                new Animal()
                {
                    ChipNumber = 3,
                    Name = "Zosia",
                    BirthDate = new DateTime(2020, 10, 10, 0, 0, 0),
                    Sex = "F",
                    FoundDate = new DateTime(2020, 10, 10, 0, 0, 0),
                    FoundPlace = "Warszawa",
                    StatusId = 3,
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
                     
                    ChipNumber = 1,
                    BirthDate = new DateTime(2008, 10, 10, 0, 0, 0),
                    Sex = "M",
                    FoundDate = new DateTime(2020, 10, 10, 0, 0, 0),
                    FoundPlace = "Miejsce",
                    StatusId = 2,
                    SpeciesId = 4
                }


            };
            return animals;
        }
        private IEnumerable<Person> GetPersons()
        {
            var persons = new List<Person>()
            {
                //weterynarz
                new Person()
                {
                    //id = 7
                    FirstName = "Anna",
                    LastName = "Vetowa",
                    PESEL = "111111111",
                    Sex = "F",
                    Address = "Weterynaryjna 8, Warszawa",
                    PhoneNumber = "101101101",
                    EmailAddress = "vetkaanna@schronisko.pl",
                    Password = "AQAAAAEAACcQAAAAEAYq+o7N+Rme4n1yxX8yZG/vodgSBkjL/scZ0Vczxt8sj7lD1O3TZevwULlm8f9MqQ==" //haslo: haslo1
                },

                //pracownik przeprowadzajacy adopcje
                new Person()
                {
                    //id = 6
                    FirstName = "Krzysztof",
                    LastName = "Adopcyjny",
                    PESEL = "22222222222",
                    Sex = "M",
                    Address = "Pracownikowo 7/11, Warszawa",
                    PhoneNumber = "222222222",
                    EmailAddress = "km@op.pl"
                },

                //wolontariusz
                 new Person()
                {
                     //id = 5
                    FirstName = "Michal",
                    LastName = "Michalczyk",
                    PESEL = "22222233222",
                    Sex = "M",
                    Address = "Wakowiocza 7/20, Warszawa",
                    PhoneNumber = "222211222",
                    EmailAddress = "k2m@op.pl"
                },

                 //adoptujacy
                   new Person()
                {
                       //id = 4
                    FirstName = "Magdalena",
                    LastName = "Krzak",
                    PESEL = "22201233222",
                    Sex = "F",
                    Address = "Kasprzaka 9/20, Warszawa",
                    PhoneNumber = "999888777",
                    EmailAddress = "mkk@gmail.com"
                },

                  //admin
                    new Person()
                {
                        //id = 3
                    FirstName = "Karolina",
                    LastName = "Admin",
                    PESEL = "88888888888",
                    Sex = "F",
                    Address = "Admina 9/20, Adminowo",
                    PhoneNumber = "111111111",
                    EmailAddress = "admin@schronisko.pl",
                    Password = "AQAAAAEAACcQAAAAEAYq+o7N+Rme4n1yxX8yZG/vodgSBkjL/scZ0Vczxt8sj7lD1O3TZevwULlm8f9MqQ=="   //haslo = haslo1
                },

                   //dyrektor
                    new Person()
                {
                        //id = 2
                    FirstName = "Marcin",
                    LastName = "Dyrektorski",
                    PESEL = "99999999999",
                    Sex = "M",
                    Address = "Dyrektorska 1/11, Dyrektorowo",
                    PhoneNumber = "999999999",
                    EmailAddress = "dyrektor@schronisko.pl",
                    Password = "AQAAAAEAACcQAAAAEAYq+o7N+Rme4n1yxX8yZG/vodgSBkjL/scZ0Vczxt8sj7lD1O3TZevwULlm8f9MqQ=="   //haslo = haslo1
                },
                     //jakiś miks
                    new Person()
                {
                        //Id = 1
                    FirstName = "Patrycja",
                    LastName = "Dwurolna",
                    PESEL = "67898765432",
                    Sex = "F",
                    Address = "Aleja Dwoch Rol 56, Chorzow",
                    PhoneNumber = "234334344",
                    EmailAddress = "dwierole@pjwstk.edu.pl"
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
                   Id = 6,
                   HireDate = new DateTime(2010, 10, 10, 0, 0, 0),
                   Salary = 5000,
                   IsRoleActive = true
                },

                new Employee()
                {
                   Id = 7,
                   HireDate = new DateTime(2015, 10, 10, 0, 0, 0),
                   Salary = 3000,
                   IsRoleActive = false //ponieważ ma rolę weterynarz, nie employee

                }
            };
            return employees;
        }
        private IEnumerable<Vet> GetVets()
        {
            var vets = new List<Vet>()
            {
                new Vet()
                {
                   Id = 7,
                   PWZNumber = "111111",
                   IsRoleActive = true
                },

            };
            return vets;
        }

        private IEnumerable<GrantedRole> GetGrantedRoles()
        {
            var grantedRoles = new List<GrantedRole>()
            {
                 new GrantedRole()
                {
                   PersonId = 3,    //Admin
                   RoleId = 4       //Admin
                },
                new GrantedRole()
                {
                   PersonId = 7,    //Vetowa
                   RoleId = 5       //Vet
                },
                 new GrantedRole()
                {
                   PersonId = 6,    //Adopcyjny
                   RoleId = 2       //Employee
                },
                  new GrantedRole()
                {
                   PersonId = 2,    //Dyrektorski
                   RoleId = 3       //Ddirector
                }


            };
            return grantedRoles;
        }


       
        private IEnumerable<Vet_Specialty> GetVetSpecs()
        {
            var vetSpecs = new List<Vet_Specialty>()
            {
                new Vet_Specialty()
                {
                   VetId = 7,
                   SpecialtyId = 1,
                   ObtainingDate = new DateTime(1998, 01, 10, 0, 0, 0)
                },
                 new Vet_Specialty()
                {
                   VetId = 7,
                   SpecialtyId = 2,
                   ObtainingDate = new DateTime(1999, 01, 10, 0, 0, 0)
                },

            };
            return vetSpecs;
        }
        private IEnumerable<VetVisit> GetVetVisits()
        {
            var vetVisits = new List<VetVisit>()
            {
                new VetVisit()
                {
                   AnimalId = 1,
                   VetId = 7,
                   VisitDate = new DateTime(2021, 01, 18, 0, 0, 0),
                   Description = "Kontrola, zwierzę nie wykazuje żadnych objawów, nie przepisano żadnych leków.// Control - no symptomes are shown, no medicine is needed."
                 },
                new VetVisit()
                {
                   AnimalId = 1,
                   VetId = 7,
                   VisitDate = new DateTime(2020, 01, 10, 0, 0, 0),
                   Description = "Wykonano USG nerek, stan narzadow w normie. Zwierze ma katar. Dawkowanie lekow: pol tabletki aspiryny dziennie i jedna kropla Floxalu do prawego oka 3x dziennie. Podawac przez tydzien. // USG scanning performed, no abnormalities were found. Animal diagnosed with Feline Viral Rhinotracheitis. Medicine prescribed: 1/2 aspirine a day + one drop of Floxal 3x a day. Continue for a week."
                }
                 

            };
            return vetVisits;
        }
        private IEnumerable<Medicine> GetMedicines()
        {
            var medicines = new List<Medicine>()
            {
                new Medicine()
                {
                    Name = "aspiryna 100mg x28tab"
                },
                new Medicine()
                {
                    Name = "Floxal krople 5ml"
                },
                new Medicine()
                {
                    Name = "Floxal masc 5mg"
                }

            };
            return medicines;
        }
        private IEnumerable<PrescribedMedicine> GetPrescribedMedicine()
        {
            var prescribedMedicines = new List<PrescribedMedicine>()
            {
                new PrescribedMedicine()
                {
                    MedicineId = 3,
                    VisitId = 1,
                    Amount = 1
                },
                 new PrescribedMedicine()
                {
                    MedicineId = 2,
                    VisitId = 1,
                    Amount = 2
                }

            };
            return prescribedMedicines;
        }
        private IEnumerable<Treatment> GetTreatment()
        {
            var treatments = new List<Treatment>()
            {
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
                    Name = "kastracja"
                },

            };
            return treatments;
        }
        private IEnumerable<PerformedTreatment> GetPerformedTreatment()
        {
            var treatments = new List<PerformedTreatment>()
            {
                new PerformedTreatment()
                {
                    TreatmentId = 3,
                    VisitId = 1
                },

            };
            return treatments;
        }
        private IEnumerable<Adoption> GetAdoptions()
        {
            var adoptions = new List<Adoption>()
            {
                new Adoption()
                {
                    AdoptionDate = new DateTime(2021, 10, 10, 0, 0, 0),
                    Notes = "brak",
                    IsOwnerPickUp = true,
                    AnimalId = 1,
                    AdopterId = 4,
                    EmployeeId = 6
                },

            };
            return adoptions;
        }
    }
}
