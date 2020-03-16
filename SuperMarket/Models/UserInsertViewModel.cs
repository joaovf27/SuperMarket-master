using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketPresentationLayer.Models
{
    public class UserInsertViewModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
