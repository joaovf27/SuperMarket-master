using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mappings
{
    class InterSaleMapConfig : IEntityTypeConfiguration<SaleDTO>
    {
        public void Configure(EntityTypeBuilder<SaleDTO> builder)
        {
            builder.HasMany(c => c.ItemsSales).WithOne(c => c.Sale);

        }
    }
}
