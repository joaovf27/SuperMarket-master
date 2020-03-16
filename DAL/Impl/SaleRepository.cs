using DAL.Interfaces;
using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Impl
{
    public class SaleRepository : ISaleRepository
    {
        private readonly MarketContext ctx;
        public SaleRepository(MarketContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task Insert(SaleDTO sale)
        {
            ctx.Sales.Add(sale);

            foreach (ItemsSaleDTO item in sale.ItemsSales)
            {
                ctx.ItemSales.Add(item);
            }
            await ctx.SaveChangesAsync();
        }

    }
}
