using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketPresentationLayer.Models
{
    public class ProviderInsertViewModel
    {
        public string FantasyName { get; set; }
        public string Email { get; set; }
        public string CNPJ { get; set; }
        public string Phone { get; set; }
    }
}
