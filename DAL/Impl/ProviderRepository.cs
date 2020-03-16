using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Impl
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly MarketContext _context;
        public ProviderRepository(MarketContext context)
        {
            _context = context;
        }
        public async Task Insert(ProviderDTO provider)
        {
            _context.Providers.Add(provider);
            await _context.SaveChangesAsync();
        }
    }
}