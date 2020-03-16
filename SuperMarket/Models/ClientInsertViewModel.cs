using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketPresentationLayer.Models
{
    public class ClientInsertViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Phone { get; set; }
        public DateTime DateBirth { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
