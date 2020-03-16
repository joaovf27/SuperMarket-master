using BLL.Interfaces;
using Commom.Security;
using DAL;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class UserService : IUserService
    {
        public async Task<Response> Insert(UserDTO user)
        {
            using (MarketContext context = new MarketContext())
            {
                Response response = new Response();

                if (string.IsNullOrWhiteSpace(user.Name))
                {
                    response.Errors.Add("O nome deve ser informado");
                }
                else if (user.Name.Length < 2 && user.Name.Length > 45)
                {
                    response.Errors.Add("O nome deve conter entre 2 e 45 caracteres");
                    response.Success = false;
                    return response;
                }

                if (response.Errors.Count != 0)
                {
                    response.Success = false;
                    return response;
                }

                try
                {
                    context.Users.Add(user);
                    await context.SaveChangesAsync();
                    response.Success = true;
                    return response;
                }
                catch (Exception ex)
                {
                    response.Errors.Add("Erro no banco contate o adm");
                    response.Success = false;
                    File.WriteAllText("Log.txt", ex.Message);
                    return response;
                }
            }
        }

        public Task<List<UserDTO>> GetUser()
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Authenticate(string email, string passWord)
        {
            using (MarketContext context = new MarketContext())
            {
                UserDTO user = await context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email) && u.Password.Equals(Password.HashPassword(passWord))).ConfigureAwait(false);
                Response response = new Response();

                if (user == null)
                {
                    response.Success = false;
                    response.Errors.Add("Usuario nao encontrado");
                    return response;
                }
                response.Success = true;
                return response;
            }
        }
    }
}
