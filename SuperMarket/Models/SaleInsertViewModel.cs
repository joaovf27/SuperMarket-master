using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketPresentationLayer.Models
{
    public class SaleInsertViewModel
    {
        public virtual ClientDTO Client { get; set; }
        public int ClientDTOID { get; set; }
        public DateTime SaleDate { get; set; }
        public double TotalPrice { get; set; }
        public EmployeeDTO Employee { get; set; }
        public ICollection<ItemsSaleDTO> ItemsSales { get; set; }
    }
}
