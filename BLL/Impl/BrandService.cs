using BLL.Interfaces;
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
    public class BrandService : IBrandService
    {
        private readonly MarketContext _context;
        private IBrandRepository _brandRepository;
        public BrandService(IBrandRepository brandrepository, MarketContext context)
        {
            this._context = context;
            this._brandRepository = brandrepository;
        }
        public async Task<Response> Insert(BrandDTO brands)
        {
            Response response = new Response();

            if (string.IsNullOrWhiteSpace(brands.Name))
            {
                response.Errors.Add("O nome da marca deve ser informado");
            }
            else if (brands.Name.Length < 2 && brands.Name.Length > 20)
            {
                response.Errors.Add("O nome da marca deve conter entre 2 e 20 caracteres =3");
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
                await _brandRepository.Insert(brands);
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

        public async Task<List<BrandDTO>> GetBrands()
        {
              return await _context.Brands.ToListAsync();
        }
    }
}
