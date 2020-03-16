using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ProductCategoryDTO
    {
        public int ProductID { get; set; }
        public ProductDTO Product { get; set; }
        public int CategoryID { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
