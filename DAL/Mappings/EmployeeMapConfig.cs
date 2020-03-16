using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mappings
{
    class EmployeeMapConfig : IEntityTypeConfiguration<EmployeeDTO>
    {
        public void Configure(EntityTypeBuilder<EmployeeDTO> builder)
        {
            builder.ToTable("EMPLOYEES");
            builder.Property(c => c.Name).IsRequired().HasMaxLength(45);
            builder.Property(c => c.Phone).IsRequired().HasMaxLength(18);
            builder.HasIndex(c => c.Phone).IsUnique(true);
            builder.Property(c => c.Password).IsRequired().HasMaxLength(100);
            builder.Property(c => c.RG).IsRequired().IsFixedLength().HasMaxLength(10);
            builder.HasIndex(c => c.RG).IsUnique(true);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(70);
            builder.HasIndex(c => c.Email).IsUnique(true);
            builder.Property(c => c.Function).IsRequired();
            builder.Property(c => c.DateBirth).IsRequired();
            builder.Property(c => c.DateBirth).HasColumnType("date");
        }
    }
}
