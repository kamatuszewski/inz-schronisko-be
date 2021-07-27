using AnimalShelter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Application.Interfaces
{
    public interface IAnimalShelterDbContext
    {
        DbSet<Admin> Admins { get; set; }
        DbSet<Adopter> Adopters { get; set; }
        DbSet<Adoption> Adoptions { get; set; }
        DbSet<AdoptionOfficeWorker> AdoptionOfficeWorkers { get; set; }
        DbSet<Animal> Animals { get; set; }
        DbSet<Director> Directors { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<GrantedRole> GrantedRoles { get; set; }
        DbSet<Medicine> Medicines { get; set; }
        DbSet<PerformedTreatment> PerformedTreatments { get; set; }
        DbSet<Person> People { get; set; }
        DbSet<PrescribedMedicine> PrescribedMedicines { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Specialty> Specialties { get; set; }
        DbSet<Species> Species { get; set; }
        DbSet<Status> Statuses { get; set; }
        DbSet<Treatment> Treatments { get; set; }
        DbSet<Vet> Vets { get; set; }
        DbSet<VetSpecialty> VetSpecialties { get; set; }
        DbSet<VetVisit> VetVisits { get; set; }
        DbSet<Volunteer> Volunteers { get; set; }
    }
}
