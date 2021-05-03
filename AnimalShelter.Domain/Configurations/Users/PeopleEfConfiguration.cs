
using AnimalShelter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Domain.Configurations
{
    public class PeopleEfConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(e => e.IdPerson).HasName("Person_PK");
            builder.Property(e => e.FirstName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.PESEL).HasMaxLength(11).IsRequired();
            builder.Property(e => e.Sex).HasMaxLength(36).IsRequired();

            builder.HasOne(d => d.Director).WithOne(p => p.Person)
              .HasForeignKey<Director>(d => d.IdDirector)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("Person_Director");
        }
    }
}
