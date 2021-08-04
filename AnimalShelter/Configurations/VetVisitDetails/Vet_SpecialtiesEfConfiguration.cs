
using AnimalShelter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Configurations
{
    public class Vet_SpecialtiesEfConfiguration : IEntityTypeConfiguration<Vet_Specialty>
    {
        public void Configure(EntityTypeBuilder<Vet_Specialty> builder)
        {
            builder.HasKey(e => new {e.IdVet, e.IdSpecialty}).HasName("Vet_Specialty_PK");
            builder.Property(e => e.ObtainingDate).IsRequired();
            builder.HasOne(d => d.Vet).WithMany(p => p.Vet_Specialties)
                .HasForeignKey(d => d.IdVet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Vet_Specialty_Vet");
            builder.HasOne(d => d.Specialty).WithMany(p => p.Vet_Specialties)
               .HasForeignKey(d => d.IdSpecialty)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("Vet_Specialty_Specialty");
        }
    }
}

