using Commom.Security;
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
    public class ClientRepositoryADO : IClientRepository
    {
        private readonly DbOptionsADO _options;
        public ClientRepositoryADO(DbOptionsADO options)
        {
            this._options = options;
        }
        public Task<List<ClientDTO>> GetClient()
        {
            throw new NotImplementedException();
        }

        public Task<List<ClientDTO>> GetClients(int page, int size)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(ClientDTO client)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _options.ConnectionString;
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO CLIENTS (NAME, EMAIL, CPF, RG, PHONE, DATEBIRTH, PASSWORD) VALUES (@NAME, @EMAIL, @CPF, @RG, @PHONE, @DATEBIRTH, @PASSWORD); select scope_identity()";
            command.Parameters.AddWithValue(@"NAME", client.Name);
            command.Parameters.AddWithValue(@"EMAIL", client.Email);
            command.Parameters.AddWithValue(@"CPF", client.CPF);
            command.Parameters.AddWithValue(@"RG", client.RG);
            command.Parameters.AddWithValue(@"PHONE", client.Phone);
            command.Parameters.AddWithValue(@"DATEBIRTH", client.DateBirth);
            command.Parameters.AddWithValue(@"PASSWORD", Password.HashPassword(client.Password));
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
