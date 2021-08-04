
using AnimalShelter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Domain.Configurations
{
    public class SpecialtiesEfConfiguration : IEntityTypeConfiguration<Specialty>
    {
        public void Configure(EntityTypeBuilder<Specialty> builder)
        {
            builder.HasKey(e => e.Id).HasName("Specialty_PK");
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.MinSalary).IsRequired();

        }
    }
}

