
using AnimalShelter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Configurations
{
    public class GrantedRolesEfConfiguration : IEntityTypeConfiguration<GrantedRole>
    {
        public void Configure(EntityTypeBuilder<GrantedRole> builder)
        {
            builder.HasKey(e => new {e.IdPerson, e.IdRole}).HasName("GrantedRoles_PK");
            builder.HasOne(d => d.Person).WithMany(p => p.GrantedRoles)
                .HasForeignKey(d => d.IdPerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GrantedRole_Person");
            builder.HasOne(d => d.Role).WithMany(p => p.GrantedRoles)
               .HasForeignKey(d => d.IdRole)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("GrantedRole_Role");
        }
    }
}

