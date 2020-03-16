using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<Response> Insert(CategoryDTO category);
        Task<List<CategoryDTO>> GetCategory();


    }
}
