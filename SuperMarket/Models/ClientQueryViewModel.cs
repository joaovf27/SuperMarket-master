using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketPresentationLayer.Models
{
    public class ClientQueryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Phone { get; set; }
        public DateTime DateBirth { get; set; }
    }
}
