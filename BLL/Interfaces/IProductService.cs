using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProductService
    {
        Task<Response> Insert(ProductDTO product);
        Task<List<ProductDTO>> GetProduct();
    }
}
