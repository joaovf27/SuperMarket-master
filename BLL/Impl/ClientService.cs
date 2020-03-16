using BLL.Interfaces;
using Commom.Security;
using DAL;
using DAL.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class ClientService : IClientService
    {
        private readonly MarketContext _context;
        private IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository, MarketContext context)
        {
            this._context = context;
            this._clientRepository = clientRepository;
        }
        public async Task<Response> Insert(ClientDTO client)
        {
            Response response = new Response();

                if (string.IsNullOrWhiteSpace(client.Name))
                {
                    response.Errors.Add("O cliente deve ser informado");
                }
                else if (client.Name.Length < 2 && client.Name.Length > 20)
                {
                    response.Errors.Add("O cliente deve conter entre 2 e 50 caracteres =3");
                    response.Success = false;
                    return response;
                }
                client.Password = Password.HashPassword(client.Password);

                if (response.Errors.Count != 0)
                {
                    response.Success = false;
                    return response;
                }

                try
                {
                    await _clientRepository.Insert(client);
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

        public async Task<List<ClientDTO>> GetClient(int page, int size)
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<List<ClientDTO>> GetClient()
        {
            return await _context.Clients.ToListAsync();
        }
    }

}    
