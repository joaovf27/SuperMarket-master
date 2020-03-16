using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mappings
{
    class ProductsProviderMapConfig : IEntityTypeConfiguration<ProviderDTO>
    {
        public void Configure(EntityTypeBuilder<ProviderDTO> builder)
        {
            builder.HasMany(c => c.Products).WithOne(c => c.Provider);
        }
    }
}
