
using AnimalShelter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Configurations
{
    public class AdoptersEfConfiguration : IEntityTypeConfiguration<Adopter>
    {
        public void Configure(EntityTypeBuilder<Adopter> builder)
        {
            builder.HasKey(e => e.Id).HasName("Adopter_PK");
          //  builder.HasOne(d => d.Person).WithMany(p => p.Adoptions)
           //     .HasForeignKey(d => d.Id)
           //     .OnDelete(DeleteBehavior.ClientSetNull)
           //     .HasConstraintName("Person_Adopter");
        }
    }
}


