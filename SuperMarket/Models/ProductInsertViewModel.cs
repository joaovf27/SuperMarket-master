using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketPresentationLayer.Models
{
    public class ProductInsertViewModel
    {
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Provider { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
    }
}
