using AnimalShelter.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class PeopleDbContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Volunteer> Volunteer { get; set; }
        public DbSet<Adopter> Adopter { get; set; }
        public DbSet<Vet> Vet { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<AdoptionOfficeWorker> AdoptionOfficeWorker { get; set; }
        public DbSet<Director> Director { get; set; }




        public PeopleDbContext() { }
        public PeopleDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PeopleEfConfiguration());
            modelBuilder.ApplyConfiguration(new AdminsEfConfiguration());
            modelBuilder.ApplyConfiguration(new AOWorkersEfConfiguration());
            modelBuilder.ApplyConfiguration(new DirectorEfConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeesEfConfiguration());
            modelBuilder.ApplyConfiguration(new VetsEfConfiguration());
            modelBuilder.ApplyConfiguration(new VolunteersEfConfiguration());


            /*    modelBuilder.Entity<Person>(entity =>
                {
                    entity.HasKey(e => e.IdPerson).HasName("Person_PK");
                    entity.Property(e => e.FirstName).HasMaxLength(255).IsRequired();
                    entity.Property(e => e.LastName).HasMaxLength(255).IsRequired();
                    entity.Property(e => e.PESEL).HasMaxLength(11).IsRequired();
                    entity.Property(e => e.Sex).HasMaxLength(36).IsRequired();

                });
            
            modelBuilder.Entity<Volunteer>(entity =>
            {
                entity.HasKey(e => e.IdVolunteer).HasName("Volunteer_PK");
                entity.Property(e => e.JoiningDate).IsRequired();
                entity.Property(e => e.Attendance).HasMaxLength(255);
                entity.HasOne(d => d.Person).WithMany(p => p.Volunteers)
                   .HasForeignKey(d => d.IdVolunteer)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("Prescrition_Patient");
            });*/
        }
    }
}
