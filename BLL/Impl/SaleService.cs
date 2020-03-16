using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
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
        private readonly ISaleRepository saleRepository;
        public SaleService(ISaleRepository saleRepository)
        {
            this.saleRepository = saleRepository;
        }

        public async Task<Response> Insert(SaleDTO sale)
        {
            Response response = new Response();

            if (sale.ItemsSales.Count <= 0)
            {
                response.Errors.Add("Não há nenhum produto na venda");
            }

            if (response.Errors.Count != 0)
            {
                response.Success = false;
                return response;
            }

            sale.CalculatePrice();

            try
            {
                await saleRepository.Insert(sale);
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

        public Task<List<CategoryDTO>> GetSales()
        {
            throw new NotImplementedException();
        }
    }
}