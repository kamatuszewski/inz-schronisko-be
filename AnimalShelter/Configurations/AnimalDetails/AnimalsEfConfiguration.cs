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
    public class AnimalsEfConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(e => e.Id).HasName("Animal_PK");
            builder.Property(e => e.ChipNumber).IsRequired();
            builder.Property(e => e.Name).HasMaxLength(255);
            builder.Property(e => e.BirthDate).IsRequired();
            builder.Property(e => e.Sex).IsRequired();
            builder.Property(e => e.FoundDate).IsRequired().HasMaxLength(255);
            builder.Property(e => e.FoundPlace).IsRequired();

            builder.HasOne(d => d.Species).WithMany(p => p.Animals)
                .HasForeignKey(d => d.SpeciesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Animal_Species");

            builder.HasOne(d => d.Status).WithMany(p => p.Animals)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Animal_Status");
        }
    }
}

