using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class BrandDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<ProductDTO> Products { get; set; }
    }
}
