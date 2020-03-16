using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<Response> Insert(UserDTO user);
        Task<List<UserDTO>> GetUser();
        Task<Response> Authenticate(string email, string passWord);

    }
}
