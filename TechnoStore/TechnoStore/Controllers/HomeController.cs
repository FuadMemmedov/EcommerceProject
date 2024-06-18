using AutoMapper;
using Business.DTOs.ProductDTOs;
using Business.Service.Abstracts;
using Core.RepositoryAbstracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechnoStore.ViewModels;

namespace TechnoStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IProductService _productService;

        
        public HomeController(ISliderService sliderService, IProductService productService)
        {
            _sliderService = sliderService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            HomeVm homeVm = new HomeVm
            {
                Products = _productService.GetAllProducts(x => x.IsDeleted == false),
                Sliders = _sliderService.GetAllSliders(x => x.IsDeleted == false)
            };

            return View(homeVm);
        }

       

		






	}
}
