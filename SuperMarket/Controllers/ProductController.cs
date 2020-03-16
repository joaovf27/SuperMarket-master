using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Impl;
using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using SuperMarketPresentationLayer.Models;

namespace SuperMarketPresentationLayer.Controllers
{
    public class ProductController : Controller
    {
        private ICategoryService _categoryService;
        public ProductController(ICategoryService categoryservice)
        {
            this._categoryService = categoryservice;
        }
        private IBrandService _brandService;
        public ProductController(IBrandService brandService)
        {
            this._brandService = brandService;
        }
        ProviderService providerSvc = new ProviderService();
        
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Insert()
        {
            ViewBag.Brands = await _brandService.GetBrands();
            ViewBag.Provider = await providerSvc.GetProvider();
            ViewBag.Category = await this._categoryService.GetCategory();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(ProductInsertViewModel viewmodel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductInsertViewModel, ProductDTO>();
            });
            IMapper mapper = configuration.CreateMapper();
            // new SERService().GetSERByID(4);
            //Transforma o ClienteInsertViewModel em um ClienteDTO
            ProductDTO dto = mapper.Map<ProductDTO>(viewmodel);
            
            try
            {
                await new ProductService().Insert(dto);
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