using System;
using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AnimalShelter.Infrastructure.Models
{
    public partial class AnimalShelterDbContext : DbContext, IAnimalShelterDbContext
    {
        public AnimalShelterDbContext()
        {
        }

        public AnimalShelterDbContext(DbContextOptions<AnimalShelterDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Adopter> Adopters { get; set; }
        public virtual DbSet<Adoption> Adoptions { get; set; }
        public virtual DbSet<AdoptionOfficeWorker> AdoptionOfficeWorkers { get; set; }
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<GrantedRole> GrantedRoles { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<PerformedTreatment> PerformedTreatments { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PrescribedMedicine> PrescribedMedicines { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Specialty> Specialties { get; set; }
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Treatment> Treatments { get; set; }
        public virtual DbSet<Vet> Vets { get; set; }
        public virtual DbSet<VetSpecialty> VetSpecialties { get; set; }
        public virtual DbSet<VetVisit> VetVisits { get; set; }
        public virtual DbSet<Volunteer> Volunteers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=172.21.40.106;Initial Catalog=animalshelter_v3;Persist Security Info=True;User ID=SA;Password=Inzynier2021!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Admin)
                    .HasForeignKey<Admin>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Person_Admin");
            });

            modelBuilder.Entity<Adopter>(entity =>
            {
                entity.ToTable("Adopter");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Adopter)
                    .HasForeignKey<Adopter>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Person_Adopter");
            });

            modelBuilder.Entity<Adoption>(entity =>
            {
                entity.ToTable("Adoption");

                entity.HasIndex(e => e.IdAdopter, "IX_Adoption_IdAdopter");

                entity.HasIndex(e => e.IdAnimal, "IX_Adoption_IdAnimal");

                entity.HasIndex(e => e.IdEmployee, "IX_Adoption_IdEmployee");

                entity.HasOne(d => d.IdAdopterNavigation)
                    .WithMany(p => p.Adoptions)
                    .HasForeignKey(d => d.IdAdopter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Adoption_Adopter");

                entity.HasOne(d => d.IdAnimalNavigation)
                    .WithMany(p => p.Adoptions)
                    .HasForeignKey(d => d.IdAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Adoption_Animal");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Adoptions)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Adoption_AOWorkerr");
            });

            modelBuilder.Entity<AdoptionOfficeWorker>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("AOWorker_PK");

                entity.ToTable("AdoptionOfficeWorker");

                entity.HasIndex(e => e.IdSpecies, "IX_AdoptionOfficeWorker_IdSpecies");

                entity.Property(e => e.IdEmployee).ValueGeneratedNever();

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithOne(p => p.AdoptionOfficeWorker)
                    .HasForeignKey<AdoptionOfficeWorker>(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_AOWorker");

                entity.HasOne(d => d.IdSpeciesNavigation)
                    .WithMany(p => p.AdoptionOfficeWorkers)
                    .HasForeignKey(d => d.IdSpecies)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_Species");
            });

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.ToTable("Animal");

                entity.HasIndex(e => e.IdSpecies, "IX_Animal_IdSpecies");

                entity.HasIndex(e => e.IdStatus, "IX_Animal_IdStatus");

                entity.Property(e => e.FoundPlace).IsRequired();

                entity.Property(e => e.Sex).IsRequired();

                entity.HasOne(d => d.IdSpeciesNavigation)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.IdSpecies)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Animal_Species");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Animal_Status");
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.ToTable("Director");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Director)
                    .HasForeignKey<Director>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Person_Director");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Person_Emplyee");
            });

            modelBuilder.Entity<GrantedRole>(entity =>
            {
                entity.HasKey(e => new { e.IdPerson, e.IdRole })
                    .HasName("GrantedRoles_PK");

                entity.ToTable("GrantedRole");

                entity.HasIndex(e => e.IdRole, "IX_GrantedRole_IdRole");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.GrantedRoles)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GrantedRole_Person");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.GrantedRoles)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GrantedRole_Role");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.ToTable("Medicine");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<PerformedTreatment>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdVisit })
                    .HasName("PerformedTreatment_PK");

                entity.ToTable("PerformedTreatment");

                entity.HasIndex(e => e.IdVisit, "IX_PerformedTreatment_IdVisit");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.PerformedTreatments)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PerformedTreatment_Treatment");

                entity.HasOne(d => d.IdVisitNavigation)
                    .WithMany(p => p.PerformedTreatments)
                    .HasForeignKey(d => d.IdVisit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PerformedTreatment_Visit");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Pesel)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("PESEL");

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(36);
            });

            modelBuilder.Entity<PrescribedMedicine>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdVisit })
                    .HasName("PrescribedMedicine_PK");

                entity.ToTable("PrescribedMedicine");

                entity.HasIndex(e => e.IdVisit, "IX_PrescribedMedicine_IdVisit");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.PrescribedMedicines)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PrescribedMedicine_Medicine");

                entity.HasOne(d => d.IdVisitNavigation)
                    .WithMany(p => p.PrescribedMedicines)
                    .HasForeignKey(d => d.IdVisit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PrescribedMedicine_Visit");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Specialty>(entity =>
            {
                entity.ToTable("Specialty");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Species>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Treatment>(entity =>
            {
                entity.ToTable("Treatment");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Vet>(entity =>
            {
                entity.ToTable("Vet");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Pwznumber)
                    .IsRequired()
                    .HasColumnName("PWZNumber");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Vet)
                    .HasForeignKey<Vet>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_Vet");
            });

            modelBuilder.Entity<VetSpecialty>(entity =>
            {
                entity.HasKey(e => new { e.IdVet, e.IdSpecialty })
                    .HasName("Vet_Specialty_PK");

                entity.ToTable("Vet_Specialty");

                entity.HasIndex(e => e.IdSpecialty, "IX_Vet_Specialty_IdSpecialty");

                entity.HasOne(d => d.IdSpecialtyNavigation)
                    .WithMany(p => p.VetSpecialties)
                    .HasForeignKey(d => d.IdSpecialty)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Vet_Specialty_Specialty");

                entity.HasOne(d => d.IdVetNavigation)
                    .WithMany(p => p.VetSpecialties)
                    .HasForeignKey(d => d.IdVet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Vet_Specialty_Vet");
            });

            modelBuilder.Entity<VetVisit>(entity =>
            {
                entity.ToTable("VetVisit");

                entity.HasIndex(e => e.IdAnimal, "IX_VetVisit_IdAnimal");

                entity.HasIndex(e => e.IdVet, "IX_VetVisit_IdVet");

                entity.Property(e => e.Description).IsRequired();

                entity.HasOne(d => d.IdAnimalNavigation)
                    .WithMany(p => p.VetVisits)
                    .HasForeignKey(d => d.IdAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VetVisit_Animal");

                entity.HasOne(d => d.IdVetNavigation)
                    .WithMany(p => p.VetVisits)
                    .HasForeignKey(d => d.IdVet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VetVisit_Vet");
            });

            modelBuilder.Entity<Volunteer>(entity =>
            {
                entity.ToTable("Volunteer");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Attendance).HasMaxLength(255);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Volunteer)
                    .HasForeignKey<Volunteer>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Person_Volunteer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
