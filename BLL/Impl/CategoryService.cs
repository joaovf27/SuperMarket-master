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
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryrepository)
        {
            this._categoryRepository = categoryrepository;
        }
        public async Task<List<CategoryDTO>> GetCategory()
        {
            return await _categoryRepository.GetCategories();
        }

        public async Task<Response> Insert(CategoryDTO category)
        {
            Response response = new Response();

            if (string.IsNullOrWhiteSpace(category.Name))
            {
                response.Errors.Add("O nome deve ser informado");
            }
            else if (category.Name.Length < 2 && category.Name.Length > 30)
            {
                response.Errors.Add("O nome da categoria deve conter entre 2 e 30 caracteres =3");
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
                await _categoryRepository.Insert(category);
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
}

