
using AnimalShelter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Configurations
{
    public class AnimalsEfConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(e => e.Id).HasName("Animal_PK");
            builder.Property(e => e.ShelterNumber).IsRequired();
            builder.Property(e => e.ChipNumber).IsRequired();
            builder.Property(e => e.BirthYear).IsRequired();
            builder.Property(e => e.Sex).IsRequired();
            builder.Property(e => e.FoundDate).IsRequired();
            builder.Property(e => e.FoundPlace).IsRequired();

            builder.HasOne(d => d.Species).WithMany(p => p.Animals)
                .HasForeignKey(d => d.IdSpecies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Animal_Species");

            builder.HasOne(d => d.Status).WithMany(p => p.Animals)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Animal_Status");
        }
    }
}

