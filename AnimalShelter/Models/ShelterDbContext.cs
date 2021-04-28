using AnimalShelter.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class ShelterDbContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Volunteer> Volunteer { get; set; }
        public DbSet<Adopter> Adopter { get; set; }
        public DbSet<Vet> Vet { get; set; }
        public DbSet<AdoptionOfficeWorker> AdoptionOfficeWorker { get; set; }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<Adoption> Adoption { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<PerformedTreatment> PerformedTreatment { get; set; }
        public DbSet<PrescribedMedicine> PrescribedMedicine { get; set; }
        public DbSet<Specialty> Specialty { get; set; }
        public DbSet<Treatment> Treatment { get; set; }
        public DbSet<Vet_Specialty> Vet_Specialty { get; set; }
        public DbSet<VetVisit> VetVisit { get; set; }


        public DbSet<Director> Director { get; set; } //to be removed?
        public DbSet<Admin> Admin { get; set; } //to be removed?



        public ShelterDbContext() { }
        public ShelterDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AnimalsEfConfiguration());
            modelBuilder.ApplyConfiguration(new AdoptionsEfConfiguration());
            modelBuilder.ApplyConfiguration(new SpeciesEfConfiguration());
            modelBuilder.ApplyConfiguration(new StatusesEfConfiguration());
            
            modelBuilder.ApplyConfiguration(new PeopleEfConfiguration());
            modelBuilder.ApplyConfiguration(new AdminsEfConfiguration());
            modelBuilder.ApplyConfiguration(new AOWorkersEfConfiguration());
            modelBuilder.ApplyConfiguration(new DirectorEfConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeesEfConfiguration());
            modelBuilder.ApplyConfiguration(new VetsEfConfiguration());
            modelBuilder.ApplyConfiguration(new VolunteersEfConfiguration());
            modelBuilder.ApplyConfiguration(new AdoptersEfConfiguration());
            modelBuilder.ApplyConfiguration(new GrantedRolesEfConfiguration());
            modelBuilder.ApplyConfiguration(new RolesEfConfiguration());

            modelBuilder.ApplyConfiguration(new MedicinesEfConfiguration());
            modelBuilder.ApplyConfiguration(new PerformedTreatmentsEfConfiguration());
            modelBuilder.ApplyConfiguration(new PrescribedMedicineEfConfiguration());
            modelBuilder.ApplyConfiguration(new SpecialtiesEfConfiguration());
            modelBuilder.ApplyConfiguration(new TreatmentsEfConfiguration());
            modelBuilder.ApplyConfiguration(new Vet_SpecialtiesEfConfiguration());
            modelBuilder.ApplyConfiguration(new VetVisitsEfConfiguration());
            

        }
    }
}
