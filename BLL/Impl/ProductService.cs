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
    public class ProductService : IProductService
    {
        public async Task<Response> Insert(ProductDTO product)
        {
            using (MarketContext context = new MarketContext())
            {
                Response response = new Response();

                if (string.IsNullOrWhiteSpace(product.Description))
                {
                    response.Errors.Add("O nome do produto deve ser informado");
                }
                else if (product.Description.Length < 2 && product.Description.Length > 40)
                {
                    response.Errors.Add("O nome do produto deve conter entre 2 e 40 caracteres");
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
                    context.Products.Add(product);
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
        

        public async Task<List<ProductDTO>> GetProduct()
        {
            using (MarketContext context = new MarketContext())
            {
                return await context.Products.ToListAsync();
            }
        }
    }
}
