
using AnimalShelter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Domain.Configurations
{

    public class StatusesEfConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(e => e.IdStatus).HasName("Status_PK");
            builder.Property(e => e.Name).HasMaxLength(255).IsRequired();
  
        }
    }
}
