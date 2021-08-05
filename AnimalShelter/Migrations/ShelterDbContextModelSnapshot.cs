﻿// <auto-generated />
using System;
using AnimalShelter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnimalShelter_WebAPI.Migrations
{
    [DbContext(typeof(ShelterDbContext))]
    partial class ShelterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AnimalShelter.Models.Adopter", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("Adopter_PK");

                    b.ToTable("Adopter");
                });

            modelBuilder.Entity("AnimalShelter.Models.Adoption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AdoptionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ControlDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAdopter")
                        .HasColumnType("int");

                    b.Property<int>("IdAnimal")
                        .HasColumnType("int");

                    b.Property<int>("IdEmployee")
                        .HasColumnType("int");

                    b.Property<bool>("IsItOwnerPickUp")
                        .HasColumnType("bit");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("Adoption_PK");

                    b.HasIndex("IdAdopter");

                    b.HasIndex("IdAnimal");

                    b.HasIndex("IdEmployee");

                    b.ToTable("Adoption");
                });

            modelBuilder.Entity("AnimalShelter.Models.AdoptionOfficeWorker", b =>
                {
                    b.Property<int>("IdEmployee")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("IdSpecies")
                        .HasColumnType("int");

                    b.HasKey("IdEmployee")
                        .HasName("AOWorker_PK");

                    b.HasIndex("IdSpecies");

                    b.ToTable("AdoptionOfficeWorker");
                });

            modelBuilder.Entity("AnimalShelter.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ChipNumber")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeathDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FoundDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FoundPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdSpecies")
                        .HasColumnType("int");

                    b.Property<int>("IdStatus")
                        .HasColumnType("int");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("Animal_PK");

                    b.HasIndex("IdSpecies");

                    b.HasIndex("IdStatus");

                    b.ToTable("Animal");
                });

            modelBuilder.Entity("AnimalShelter.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("QuitDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("Employee_PK");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("AnimalShelter.Models.GrantedRole", b =>
                {
                    b.Property<int>("IdPerson")
                        .HasColumnType("int");

                    b.Property<int>("IdRole")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("IdPerson", "IdRole")
                        .HasName("GrantedRoles_PK");

                    b.HasIndex("IdRole");

                    b.ToTable("GrantedRole");
                });

            modelBuilder.Entity("AnimalShelter.Models.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("Medicine_PK");

                    b.ToTable("Medicine");
                });

            modelBuilder.Entity("AnimalShelter.Models.PerformedTreatment", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("IdVisit")
                        .HasColumnType("int");

                    b.HasKey("Id", "IdVisit")
                        .HasName("PerformedTreatment_PK");

                    b.HasIndex("IdVisit");

                    b.ToTable("PerformedTreatment");
                });

            modelBuilder.Entity("AnimalShelter.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PESEL")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("Id")
                        .HasName("Person_PK");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("AnimalShelter.Models.PrescribedMedicine", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("IdVisit")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("Id", "IdVisit")
                        .HasName("PrescribedMedicine_PK");

                    b.HasIndex("IdVisit");

                    b.ToTable("PrescribedMedicine");
                });

            modelBuilder.Entity("AnimalShelter.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("Role_PK");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("AnimalShelter.Models.Specialty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MinSalary")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("Specialty_PK");

                    b.ToTable("Specialty");
                });

            modelBuilder.Entity("AnimalShelter.Models.Species", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("Species_PK");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("AnimalShelter.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("Status_PK");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("AnimalShelter.Models.Treatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("Treatment_PK");

                    b.ToTable("Treatment");
                });

            modelBuilder.Entity("AnimalShelter.Models.Vet", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("PWZNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("Vet_PK");

                    b.ToTable("Vet");
                });

            modelBuilder.Entity("AnimalShelter.Models.VetVisit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdAnimal")
                        .HasColumnType("int");

                    b.Property<int>("IdVet")
                        .HasColumnType("int");

                    b.Property<DateTime>("VisitDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id")
                        .HasName("VetVisit_PK");

                    b.HasIndex("IdAnimal");

                    b.HasIndex("IdVet");

                    b.ToTable("VetVisit");
                });

            modelBuilder.Entity("AnimalShelter.Models.Vet_Specialty", b =>
                {
                    b.Property<int>("IdVet")
                        .HasColumnType("int");

                    b.Property<int>("IdSpecialty")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("ObtainingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdVet", "IdSpecialty")
                        .HasName("Vet_Specialty_PK");

                    b.HasIndex("IdSpecialty");

                    b.ToTable("Vet_Specialty");
                });

            modelBuilder.Entity("AnimalShelter.Models.Volunteer", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Attendance")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("JoiningDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id")
                        .HasName("Volunteer_PK");

                    b.ToTable("Volunteer");
                });

            modelBuilder.Entity("AnimalShelter.Models.Adopter", b =>
                {
                    b.HasOne("AnimalShelter.Models.Person", "Person")
                        .WithMany("Adopters")
                        .HasForeignKey("Id")
                        .HasConstraintName("Person_Adopter")
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("AnimalShelter.Models.Adoption", b =>
                {
                    b.HasOne("AnimalShelter.Models.Adopter", "Adopter")
                        .WithMany("Adoptions")
                        .HasForeignKey("IdAdopter")
                        .HasConstraintName("Adoption_Adopter")
                        .IsRequired();

                    b.HasOne("AnimalShelter.Models.Animal", "Animal")
                        .WithMany("Adoptions")
                        .HasForeignKey("IdAnimal")
                        .HasConstraintName("Adoption_Animal")
                        .IsRequired();

                    b.HasOne("AnimalShelter.Models.AdoptionOfficeWorker", "AdoptionOfficeWorker")
                        .WithMany("Adoptions")
                        .HasForeignKey("IdEmployee")
                        .HasConstraintName("Adoption_AOWorkerr")
                        .IsRequired();

                    b.Navigation("Adopter");

                    b.Navigation("AdoptionOfficeWorker");

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("AnimalShelter.Models.AdoptionOfficeWorker", b =>
                {
                    b.HasOne("AnimalShelter.Models.Employee", "Employee")
                        .WithMany("AdoptionOfficeWorkers")
                        .HasForeignKey("IdEmployee")
                        .HasConstraintName("Employee_AOWorker")
                        .IsRequired();

                    b.HasOne("AnimalShelter.Models.Species", "AssignedSpecies")
                        .WithMany("AdoptionOfficeWorkers")
                        .HasForeignKey("IdSpecies")
                        .HasConstraintName("Employee_Species")
                        .IsRequired();

                    b.Navigation("AssignedSpecies");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("AnimalShelter.Models.Animal", b =>
                {
                    b.HasOne("AnimalShelter.Models.Species", "Species")
                        .WithMany("Animals")
                        .HasForeignKey("IdSpecies")
                        .HasConstraintName("Animal_Species")
                        .IsRequired();

                    b.HasOne("AnimalShelter.Models.Status", "Status")
                        .WithMany("Animals")
                        .HasForeignKey("IdStatus")
                        .HasConstraintName("Animal_Status")
                        .IsRequired();

                    b.Navigation("Species");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("AnimalShelter.Models.Employee", b =>
                {
                    b.HasOne("AnimalShelter.Models.Person", "Person")
                        .WithMany("Employees")
                        .HasForeignKey("Id")
                        .HasConstraintName("Person_Emplyee")
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("AnimalShelter.Models.GrantedRole", b =>
                {
                    b.HasOne("AnimalShelter.Models.Person", "Person")
                        .WithMany("GrantedRoles")
                        .HasForeignKey("IdPerson")
                        .HasConstraintName("GrantedRole_Person")
                        .IsRequired();

                    b.HasOne("AnimalShelter.Models.Role", "Role")
                        .WithMany("GrantedRoles")
                        .HasForeignKey("IdRole")
                        .HasConstraintName("GrantedRole_Role")
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AnimalShelter.Models.PerformedTreatment", b =>
                {
                    b.HasOne("AnimalShelter.Models.Treatment", "Treatment")
                        .WithMany("PerformedTreatments")
                        .HasForeignKey("Id")
                        .HasConstraintName("PerformedTreatment_Treatment")
                        .IsRequired();

                    b.HasOne("AnimalShelter.Models.VetVisit", "VetVisit")
                        .WithMany("PerformedTreatments")
                        .HasForeignKey("IdVisit")
                        .HasConstraintName("PerformedTreatment_Visit")
                        .IsRequired();

                    b.Navigation("Treatment");

                    b.Navigation("VetVisit");
                });

            modelBuilder.Entity("AnimalShelter.Models.PrescribedMedicine", b =>
                {
                    b.HasOne("AnimalShelter.Models.Medicine", "Medicine")
                        .WithMany("PrescribedMedicines")
                        .HasForeignKey("Id")
                        .HasConstraintName("PrescribedMedicine_Medicine")
                        .IsRequired();

                    b.HasOne("AnimalShelter.Models.VetVisit", "VetVisit")
                        .WithMany("PrescribedMedicines")
                        .HasForeignKey("IdVisit")
                        .HasConstraintName("PrescribedMedicine_Visit")
                        .IsRequired();

                    b.Navigation("Medicine");

                    b.Navigation("VetVisit");
                });

            modelBuilder.Entity("AnimalShelter.Models.Vet", b =>
                {
                    b.HasOne("AnimalShelter.Models.Employee", "Employee")
                        .WithMany("Vets")
                        .HasForeignKey("Id")
                        .HasConstraintName("Employee_Vet")
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("AnimalShelter.Models.VetVisit", b =>
                {
                    b.HasOne("AnimalShelter.Models.Animal", "Animal")
                        .WithMany("VetVisits")
                        .HasForeignKey("IdAnimal")
                        .HasConstraintName("VetVisit_Animal")
                        .IsRequired();

                    b.HasOne("AnimalShelter.Models.Vet", "Vet")
                        .WithMany("VetVisits")
                        .HasForeignKey("IdVet")
                        .HasConstraintName("VetVisit_Vet")
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Vet");
                });

            modelBuilder.Entity("AnimalShelter.Models.Vet_Specialty", b =>
                {
                    b.HasOne("AnimalShelter.Models.Specialty", "Specialty")
                        .WithMany("Vet_Specialties")
                        .HasForeignKey("IdSpecialty")
                        .HasConstraintName("Vet_Specialty_Specialty")
                        .IsRequired();

                    b.HasOne("AnimalShelter.Models.Vet", "Vet")
                        .WithMany("Vet_Specialties")
                        .HasForeignKey("IdVet")
                        .HasConstraintName("Vet_Specialty_Vet")
                        .IsRequired();

                    b.Navigation("Specialty");

                    b.Navigation("Vet");
                });

            modelBuilder.Entity("AnimalShelter.Models.Volunteer", b =>
                {
                    b.HasOne("AnimalShelter.Models.Person", "Person")
                        .WithMany("Volunteers")
                        .HasForeignKey("Id")
                        .HasConstraintName("Person_Volunteer")
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("AnimalShelter.Models.Adopter", b =>
                {
                    b.Navigation("Adoptions");
                });

            modelBuilder.Entity("AnimalShelter.Models.AdoptionOfficeWorker", b =>
                {
                    b.Navigation("Adoptions");
                });

            modelBuilder.Entity("AnimalShelter.Models.Animal", b =>
                {
                    b.Navigation("Adoptions");

                    b.Navigation("VetVisits");
                });

            modelBuilder.Entity("AnimalShelter.Models.Employee", b =>
                {
                    b.Navigation("AdoptionOfficeWorkers");

                    b.Navigation("Vets");
                });

            modelBuilder.Entity("AnimalShelter.Models.Medicine", b =>
                {
                    b.Navigation("PrescribedMedicines");
                });

            modelBuilder.Entity("AnimalShelter.Models.Person", b =>
                {
                    b.Navigation("Adopters");

                    b.Navigation("Employees");

                    b.Navigation("GrantedRoles");

                    b.Navigation("Volunteers");
                });

            modelBuilder.Entity("AnimalShelter.Models.Role", b =>
                {
                    b.Navigation("GrantedRoles");
                });

            modelBuilder.Entity("AnimalShelter.Models.Specialty", b =>
                {
                    b.Navigation("Vet_Specialties");
                });

            modelBuilder.Entity("AnimalShelter.Models.Species", b =>
                {
                    b.Navigation("AdoptionOfficeWorkers");

                    b.Navigation("Animals");
                });

            modelBuilder.Entity("AnimalShelter.Models.Status", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("AnimalShelter.Models.Treatment", b =>
                {
                    b.Navigation("PerformedTreatments");
                });

            modelBuilder.Entity("AnimalShelter.Models.Vet", b =>
                {
                    b.Navigation("Vet_Specialties");

                    b.Navigation("VetVisits");
                });

            modelBuilder.Entity("AnimalShelter.Models.VetVisit", b =>
                {
                    b.Navigation("PerformedTreatments");

                    b.Navigation("PrescribedMedicines");
                });
#pragma warning restore 612, 618
        }
    }
}
