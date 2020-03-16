using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mappings
{
    class UserMapConfig : IEntityTypeConfiguration<UserDTO>
    {
        public void Configure(EntityTypeBuilder<UserDTO> builder)
        {
            builder.ToTable("USERS");
            builder.Property(c => c.Email).IsRequired().HasMaxLength(100);
            builder.HasIndex(c => c.Email).IsUnique(true);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(45);
            builder.Property(c => c.Password).IsRequired().HasMaxLength(100);
            
        }
    }
}
