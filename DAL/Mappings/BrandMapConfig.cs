using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mappings
{
    class BrandMapConfig : IEntityTypeConfiguration<BrandDTO>
    {
        public void Configure(EntityTypeBuilder<BrandDTO> builder)
        {
            builder.ToTable("BRANDS");
            builder.Property(c => c.Name).HasMaxLength(20);
        }
    }

}

