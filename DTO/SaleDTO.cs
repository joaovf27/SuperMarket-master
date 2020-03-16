using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class SaleDTO
    {
        public int ID { get; set; }
        public  virtual ClientDTO Client { get; set; }
        public int ClientDTOID { get; set; }
        public DateTime SaleDate { get; set; }
        public double TotalPrice { get; set; }
        public bool Finalizado { get; set; }
        public ICollection<ItemsSaleDTO> ItemsSales { get; set; }
    }
}
