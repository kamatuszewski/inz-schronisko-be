
using AnimalShelter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Domain.Configurations
{
    public class RolesEfConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(e => e.IdRole).HasName("Role_PK");
            builder.Property(e => e.Name).HasMaxLength(255).IsRequired();

        }
    }
}

