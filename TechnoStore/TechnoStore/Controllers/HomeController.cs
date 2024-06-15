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
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public HomeController(ISliderService sliderService, IProductService productService, IMapper mapper, IProductRepository productRepository)
        {
            _sliderService = sliderService;
            _productService = productService;
            _mapper = mapper;
            _productRepository = productRepository;
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

        public IActionResult Search(string? search)
        {
            var products = _productService.GetAllProducts().AsQueryable();

            if (search != null)
            {
                products = products.Where(x => x.Name.ToLower().Contains(search.ToLower()));
            }
            List<ProductGetDTO> productGetDTOs = _mapper.Map<List<ProductGetDTO>>(products);

            return View(productGetDTOs);
        }

		public IActionResult SearchPrice(decimal? minPrice,decimal? maxPrice)
		{
			var products = _productService.GetAllProducts().AsQueryable();

			if (minPrice != null || minPrice != null)
			{
				products = products.Where(x => x.Price >= minPrice && x.Price <= maxPrice);
			}
			List<ProductGetDTO> productGetDTOs = _mapper.Map<List<ProductGetDTO>>(products);

			return View(productGetDTOs);
		}






	}
}
