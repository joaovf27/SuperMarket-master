using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Mappings
{
    internal class ProductsBrandMapConfig : IEntityTypeConfiguration<BrandDTO>
    {
        public void Configure(EntityTypeBuilder<BrandDTO> builder)
        {
            builder.HasMany(c => c.Products).WithOne(c => c.Brand);
        }
    }
}
