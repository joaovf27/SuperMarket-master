using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProviderService
    {
        Task<Response> Insert(ProviderDTO provider);
        Task<List<ProviderDTO>> GetProvider();
    }
}
