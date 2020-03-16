using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Impl;
using DTO;
using Microsoft.AspNetCore.Mvc;
using SuperMarketPresentationLayer.Models;

namespace SuperMarketPresentationLayer.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Insert(EmployeeInsertViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeInsertViewModel, EmployeeDTO>();
            });
            IMapper mapper = configuration.CreateMapper();
            // new SERService().GetSERByID(4);
            //Transforma o ClienteInsertViewModel em um ClienteDTO
            EmployeeDTO dto = mapper.Map<EmployeeDTO>(viewModel);

            EmployeeService svc = new EmployeeService();
            try
            {
                await svc.Insert(dto);
                return RedirectToAction("Index", "Client");
            }
            catch (Exception ex)
            {
                ViewBag.Erros = ex.Message;
            }
            return View();
        }
    }
}