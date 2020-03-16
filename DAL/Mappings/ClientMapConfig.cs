using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mappings
{
    class ClientMapConfig : IEntityTypeConfiguration<ClientDTO>
    {
        public void Configure(EntityTypeBuilder<ClientDTO> builder)
        {
            builder.ToTable("CLIENTS");
            builder.Property(c => c.Name).HasMaxLength(45).IsRequired();
            builder.Property(c => c.RG).IsRequired().HasMaxLength(9);
            builder.Property(c => c.Password).IsRequired().HasMaxLength(80);
            builder.Property(c => c.Phone).IsRequired().HasMaxLength(18);
            builder.Property(c => c.DateBirth).IsRequired();
            builder.Property(c => c.CPF).IsRequired().HasMaxLength(14);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(70);
            builder.Property(c => c.DateBirth).HasColumnType("date");


        }
    }
}
