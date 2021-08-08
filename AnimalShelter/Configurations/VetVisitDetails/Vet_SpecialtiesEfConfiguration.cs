﻿
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
            builder.HasKey(e => new {e.VetId, e.SpecialtyId}).HasName("Vet_Specialty_PK");
            builder.Property(e => e.ObtainingDate).IsRequired();
            builder.HasOne(d => d.Vet).WithMany(p => p.Vet_Specialties)
                .HasForeignKey(d => d.VetId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Vet_Specialty_Vet");
            builder.HasOne(d => d.Specialty).WithMany(p => p.Vet_Specialties)
               .HasForeignKey(d => d.SpecialtyId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("Vet_Specialty_Specialty");
        }
    }
}

