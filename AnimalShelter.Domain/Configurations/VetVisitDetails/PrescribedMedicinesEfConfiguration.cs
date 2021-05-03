using AnimalShelter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Domain.Configurations
{
    public class PrescribedMedicineEfConfiguration : IEntityTypeConfiguration<PrescribedMedicine>
    {
        public void Configure(EntityTypeBuilder<PrescribedMedicine> builder)
        {
            builder.HasKey(e => new { e.IdMedicine, e.IdVisit }).HasName("PrescribedMedicine_PK");
            builder.Property(e => e.Amount).IsRequired();

            builder.HasOne(d => d.Medicine).WithMany(p => p.PrescribedMedicines)
                .HasForeignKey(d => d.IdMedicine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PrescribedMedicine_Medicine");
            builder.HasOne(d => d.VetVisit).WithMany(p => p.PrescribedMedicines)
               .HasForeignKey(d => d.IdVisit)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("PrescribedMedicine_Visit");
        }
    }
}

