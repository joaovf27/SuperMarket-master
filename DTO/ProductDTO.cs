using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    public class ProductDTO
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public virtual ProviderDTO Provider { get; set; }
        public virtual BrandDTO Brand{ get; set; }
        public int BrandID { get; set; }
        public int ProviderID { get; set; }
        public virtual ICollection<ProductCategoryDTO> ProductCategory { get; set; }
        public double Price { get; set; }

    }
}
