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
    public class VetVisitsEfConfiguration : IEntityTypeConfiguration<VetVisit>
    {
        public void Configure(EntityTypeBuilder<VetVisit> builder)
        {
            builder.HasKey(e => e.Id).HasName("VetVisit_PK");
            builder.Property(e => e.VisitDate).IsRequired();
            builder.Property(e => e.Description).IsRequired();

            builder.HasOne(d => d.Vet).WithMany(p => p.VetVisits)
                .HasForeignKey(d => d.VetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("VetVisit_Vet");
            builder.HasOne(d => d.Animal).WithMany(p => p.VetVisits)
               .HasForeignKey(d => d.AnimalId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("VetVisit_Animal");
        }
    }
}

