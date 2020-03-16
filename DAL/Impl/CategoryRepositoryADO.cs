using DAL.Interfaces;
using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Impl
{
    public class CategoryRepositoryADO : ICategoryRepository
    {
        private readonly DbOptionsADO _options;
        public CategoryRepositoryADO(DbOptionsADO options)
        {
            this._options = options;
        }
        public Task<List<CategoryDTO>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public async Task Insert(CategoryDTO category)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _options.ConnectionString;
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO CATEGORIES (NAME) VALUES (@NAME); select scope_identity()";
            command.Parameters.AddWithValue(@"NAME", category.Name);
            command.Connection = connection;
            Response response = new Response();
            try
            {
                await connection.OpenAsync();
                int idGerado = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                response.Errors.Add("Erro no banco de dados, contate o administrador!");
                File.WriteAllText("log.txt", ex.Message);
            }
            finally
            {
                await connection.CloseAsync();
            }
        }
    }
}
