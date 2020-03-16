using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mappings
{
    public class ProductCategoryMapConfig : IEntityTypeConfiguration<ProductCategoryDTO>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryDTO> builder)
        {
            builder.ToTable("PRODUCTS_CATEGORIES");
            builder.HasKey(bc => new { bc.ProductID, bc.CategoryID });

            builder.HasOne(bc => bc.Product)
                .WithMany(b => b.ProductCategory)
                .HasForeignKey(bc => bc.ProductID);

            builder.HasOne(bc => bc.Category)
                .WithMany(c => c.ProductCategory)
                .HasForeignKey(bc => bc.CategoryID);
                
        }
    }
}
