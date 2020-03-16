using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mappings
{
    class ItemsSaleMapConfig : IEntityTypeConfiguration<ItemsSaleDTO>
    {
        public void Configure(EntityTypeBuilder<ItemsSaleDTO> builder)
        {
        }
    }
}
