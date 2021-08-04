
using AnimalShelter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Configurations
{
    public class AdoptionsEfConfiguration : IEntityTypeConfiguration<Adoption>
    {
        public void Configure(EntityTypeBuilder<Adoption> builder)
        {
            builder.HasKey(e => e.Id).HasName("Adoption_PK");
            builder.Property(e => e.AdoptionDate).IsRequired();
            builder.Property(e => e.IsItOwnerPickUp).IsRequired();
           

            builder.HasOne(d => d.Animal).WithMany(p => p.Adoptions)
                .HasForeignKey(d => d.IdAnimal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Adoption_Animal");

            builder.HasOne(d => d.Adopter).WithMany(p => p.Adoptions)
                .HasForeignKey(d => d.IdAdopter)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Adoption_Adopter");

            builder.HasOne(d => d.AdoptionOfficeWorker).WithMany(p => p.Adoptions)
               .HasForeignKey(d => d.IdEmployee)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("Adoption_AOWorkerr");
        }
    }
}

