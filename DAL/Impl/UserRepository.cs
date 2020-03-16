using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly MarketContext _context;
        public UserRepository(MarketContext context)
        {
            _context = context;
        }
        public async Task Insert(UserDTO user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
