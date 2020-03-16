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
    public class SaleController : Controller
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
        public async Task<IActionResult> Insert(SaleInsertViewModel viewmodel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SaleInsertViewModel, SaleDTO>();
            });
            IMapper mapper = configuration.CreateMapper();
            // new SERService().GetSERByID(4);
            //Transforma o ClienteInsertViewModel em um ClienteDTO
            SaleDTO dto = mapper.Map<SaleDTO>(viewmodel);

            SaleService svc = new SaleService();
            try
            {
                await svc.Insert(dto);
                return RedirectToAction("Index", "Category");
            }
            catch (Exception ex)
            {
                ViewBag.Erros = ex.Message;
            }
            return View();
        }
        
    }
}