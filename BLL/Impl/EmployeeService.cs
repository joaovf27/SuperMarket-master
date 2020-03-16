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
    public class EmployeeService : IEmployeeService
    {
        public async Task<Response> Insert(EmployeeDTO employee)
        {
            using (MarketContext context = new MarketContext())
            {
                Response response = new Response();

                if (string.IsNullOrWhiteSpace(employee.Name))
                {
                    response.Errors.Add("O funcionário deve ser informado");
                }
                else if (employee.Name.Length < 2 && employee.Name.Length > 45)
                {
                    response.Errors.Add("O funcionário deve conter entre 2 e 45 caracteres");
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
                    context.Employees.Add(employee);
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

        public async Task<List<EmployeeDTO>> GetEmployee()
        {
            using (MarketContext context = new MarketContext())
            {
                return await context.Employees.ToListAsync();
            }
        }
        
    }
}
