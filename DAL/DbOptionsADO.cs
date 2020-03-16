using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DbOptionsADO 
    {
        public DbOptionsADO(IConfiguration configuration)
        {
            this.ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public string ConnectionString { get; set; }
    }
}
