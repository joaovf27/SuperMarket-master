using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mappings
{
    class CategoryMapConfig : IEntityTypeConfiguration<CategoryDTO>
    {
        public void Configure(EntityTypeBuilder<CategoryDTO> builder)
        {
            builder.ToTable("CATEGORIES");
            builder.Property(c => c.Name).IsRequired().HasMaxLength(30);
        }
    }
}
