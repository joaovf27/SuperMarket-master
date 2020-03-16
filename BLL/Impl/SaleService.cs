using BLL.Interfaces;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class SaleService : ISaleService
    {
        public async Task<Response> Insert(SaleDTO sale)
        {
            using (MarketContext context = new MarketContext())
            {
                Response response = new Response();

                if (sale.TotalPrice <= 0)
                {
                    response.Errors.Add("O valor da venda não pode ser menor ou igual a 0");
                }

                if (sale.ItemsSales.Count <= 0)
                {
                    response.Errors.Add("Não há nenhum produto na venda");
                }
               
                if (response.Errors.Count != 0)
                {
                    response.Success = false;
                    return response;
                }

                try
                {
                    context.Sales.Add(sale);
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

        public Task<List<CategoryDTO>> GetSales()
        {
            throw new NotImplementedException();
        }
    }
}
