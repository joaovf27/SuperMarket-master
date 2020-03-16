using BLL.Interfaces;
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
    public class ProviderService : IProviderService
    {
        public async Task<Response> Insert(ProviderDTO provider)
        {
            using (MarketContext context = new MarketContext())
            {
                Response response = new Response();

                if (string.IsNullOrWhiteSpace(provider.FantasyName))
                {
                    response.Errors.Add("O nome fantasia deve ser informado");
                }
                else if (provider.FantasyName.Length < 2 && provider.FantasyName.Length > 50)
                {
                    response.Errors.Add("O nome fantasia deve conter entre 2 e 50 caracteres");
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
                    context.Providers.Add(provider);
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

        public async Task<List<ProviderDTO>> GetProvider()
        {
            using (MarketContext context = new MarketContext())
            {
                return await context.Providers.ToListAsync();
            }
        }
    }
}
