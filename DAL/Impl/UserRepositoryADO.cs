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
    public class UserRepositoryADO : IUserRepository
    {
        private readonly DbOptionsADO _options;
        public UserRepositoryADO(DbOptionsADO options)
        {
            this._options = options;
        }
        public async Task Insert(UserDTO user)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _options.ConnectionString;
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO USERS (EMAIL,PASSWORD,NAME,PERMISSION) VALUES (@EMAIL,@PASSWORD,@NAME,@PERMISSION); select scope_identity()";
            command.Parameters.AddWithValue(@"EMAIL", user.Email);
            command.Parameters.AddWithValue(@"PASSWORD", user.Password);
            command.Parameters.AddWithValue(@"NAME", user.Name);
            command.Parameters.AddWithValue(@"PERMISSION", DTO.Enums.Permissions.Normal);
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
