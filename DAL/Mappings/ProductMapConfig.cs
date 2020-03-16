using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mappings
{
    class ProductMapConfig : IEntityTypeConfiguration<ProductDTO>
    {
        public void Configure(EntityTypeBuilder<ProductDTO> builder)
        {
            builder.ToTable("PRODUCTS");
            builder.Property(c => c.Description).IsRequired().HasMaxLength(40);
            builder.Property(c => c.Price).IsRequired();
            builder.Property(c => c.ProviderID).IsRequired();
        }
    }
}
