
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
            builder.HasKey(e => new { e.TreatmentId, e.VisitId }).HasName("PerformedTreatment_PK");

            builder.HasOne(d => d.Treatment).WithMany(p => p.PerformedTreatments)
                .HasForeignKey(d => d.TreatmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PerformedTreatment_Treatment");
            builder.HasOne(d => d.VetVisit).WithMany(p => p.PerformedTreatments)
               .HasForeignKey(d => d.VisitId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("PerformedTreatment_Visit");
        }
    }
}

