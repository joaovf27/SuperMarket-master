using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mappings
{
    class ProviderMapConfig : IEntityTypeConfiguration<ProviderDTO>
    {
        public void Configure(EntityTypeBuilder<ProviderDTO> builder)
        {
            builder.ToTable("PROVIDERS");
            builder.Property(c => c.CNPJ).IsRequired().HasMaxLength(18).IsFixedLength();
            builder.HasIndex(c => c.CNPJ).IsUnique(true);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(80);
            builder.HasIndex(c => c.Email).IsUnique(true);
            builder.Property(c => c.Phone).IsRequired().HasMaxLength(18);
            builder.HasIndex(c => c.Phone).IsUnique(true);
            builder.Property(c => c.FantasyName).IsRequired().HasMaxLength(50);
            builder.HasIndex(c => c.Email).IsUnique(true);
            builder.HasIndex(c => c.Phone).IsUnique(true);
        }
    }
}
