
using System;
using System.Collections.Generic;
using System.Text;
namespace DTO
{
    public class ProviderDTO
    {
        public int ID { get; set; }
        public string FantasyName { get; set; }
        public string Email { get; set; }
        public string CNPJ { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<ProductDTO> Products { get; set; }
    }
}
