
using AnimalShelter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Configurations
{
    public class PerformedTreatmentsEfConfiguration : IEntityTypeConfiguration<PerformedTreatment>
    {
        public void Configure(EntityTypeBuilder<PerformedTreatment> builder)
        {
            builder.HasKey(e => new { e.Id, e.IdVisit }).HasName("PerformedTreatment_PK");

            builder.HasOne(d => d.Treatment).WithMany(p => p.PerformedTreatments)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PerformedTreatment_Treatment");
            builder.HasOne(d => d.VetVisit).WithMany(p => p.PerformedTreatments)
               .HasForeignKey(d => d.IdVisit)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("PerformedTreatment_Visit");
        }
    }
}

