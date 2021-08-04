
using AnimalShelter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Configurations
{

    public class VolunteersEfConfiguration : IEntityTypeConfiguration<Volunteer>
    {
        public void Configure(EntityTypeBuilder<Volunteer> builder)
        {
            builder.HasKey(e => e.Id).HasName("Volunteer_PK");
            builder.Property(e => e.JoiningDate).IsRequired();
            builder.Property(e => e.Attendance).HasMaxLength(255);
            builder.HasOne(d => d.Person).WithMany(p => p.Volunteers)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Person_Volunteer");
        }
    }
}
