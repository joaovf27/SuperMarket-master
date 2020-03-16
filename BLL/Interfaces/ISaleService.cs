using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    interface ISaleService
    {
        Task<Response> Insert(SaleDTO sale);
        Task<List<CategoryDTO>> GetSales();
    }
}
