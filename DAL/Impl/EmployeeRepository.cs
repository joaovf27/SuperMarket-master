using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Impl
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MarketContext _context;
        public EmployeeRepository(MarketContext context)
        {
            _context = context;
        }
        public async Task Insert(EmployeeDTO employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }
    }
}
