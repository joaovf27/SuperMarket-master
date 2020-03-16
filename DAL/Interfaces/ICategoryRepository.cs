using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICategoryRepository
    {
        Task Insert(CategoryDTO category);

        Task<List<CategoryDTO>> GetCategories();
    }
}
