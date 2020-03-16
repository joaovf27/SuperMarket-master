using DAL.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Impl
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MarketContext _context;
        public CategoryRepository(MarketContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryDTO>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task Insert(CategoryDTO category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }
    }
}
