using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mappings
{
    class SaleMapConfig : IEntityTypeConfiguration<SaleDTO>
    {
        public void Configure(EntityTypeBuilder<SaleDTO> builder)
        {
            builder.ToTable("SALES");
            builder.Property(c => c.ClientDTOID).IsRequired();
            builder.Property(c => c.SaleDate).HasColumnType("date");
        }
    }
}
