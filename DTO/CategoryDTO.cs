using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO
{
    public class CategoryDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProductCategoryDTO> ProductCategory { get; set; }

    }
}
