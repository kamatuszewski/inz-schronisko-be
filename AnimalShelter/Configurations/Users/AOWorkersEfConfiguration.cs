
using AnimalShelter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Configurations
{
    public class AOWorkersEfConfiguration : IEntityTypeConfiguration<AdoptionOfficeWorker>
    {
        public void Configure(EntityTypeBuilder<AdoptionOfficeWorker> builder)
        {
            builder.HasKey(e => e.IdEmployee).HasName("AOWorker_PK");
            builder.HasOne(d => d.Employee).WithMany(p => p.AdoptionOfficeWorkers)
                .HasForeignKey(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Employee_AOWorker");

            builder.HasOne(d => d.AssignedSpecies).WithMany(p => p.AdoptionOfficeWorkers)
                .HasForeignKey(d => d.IdSpecies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Employee_Species");
        }
    }
}



