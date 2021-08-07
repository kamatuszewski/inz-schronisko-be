
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
            builder.HasKey(e => e.Id).HasName("AOWorker_PK");
            builder.HasOne(d => d.Employee).WithMany(p => p.AdoptionOfficeWorkers)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Employee_AOWorker");

        }
    }
}



