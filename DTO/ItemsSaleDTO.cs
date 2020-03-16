using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ItemsSaleDTO
    {
        public int ID { get; set; }
        public virtual ProductDTO Product { get; set; }
        public int ProductDTOID { get; set; }
        public double Price { get; set; }
        public virtual SaleDTO Sale { get; set; }
        public int SaleDTOID { get; set; }
    }
}
