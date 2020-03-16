using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IClientService
    {
        Task<Response> Insert(ClientDTO client);
        Task<List<ClientDTO>> GetClient(int page, int size);
        Task<List<ClientDTO>> GetClient();
    }
}
