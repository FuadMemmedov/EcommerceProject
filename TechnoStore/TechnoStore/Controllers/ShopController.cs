using AutoMapper;
using Business.DTOs.ProductDTOs;
using Business.Service.Abstracts;
using Data.Migrations;
using Microsoft.AspNetCore.Mvc;
using TechnoStore.ViewModels;

namespace TechnoStore.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopSliderService _shopSliderService;
        private readonly IProductService _productService;
        private readonly IProductColorService _productColorService;
        private readonly IBrandService _brandService;
		private readonly IMapper _mapper;
		private readonly ICategoryService _categoryService;

		public ShopController(IShopSliderService shopSliderService, IProductService productService, IProductColorService productColorService, IBrandService brandService, IMapper mapper, ICategoryService categoryService)
		{
			_shopSliderService = shopSliderService;
			_productService = productService;
			_productColorService = productColorService;
			_brandService = brandService;
			_mapper = mapper;
			_categoryService = categoryService;
		}

		public IActionResult Index()
        {

            ShopVm shopVm = new ShopVm
            {
                Colors = _productColorService.GetAllProductColors(x => x.IsDeleted == false),
                Brands = _brandService.GetAllBrands(x => x.IsDeleted == false),
                ShopSliders =  _shopSliderService.GetAllShopSliders(x => x.IsDeleted == false),
				Categories = _categoryService.GetAllCategories(x=>x.IsDeleted == false)
						

		    };

            return View(shopVm);
        }


        public IActionResult Detail(int id)
        {
            ShopVm shopVm = new ShopVm
            {

                Product = _productService.GetProduct(x => x.Id == id && x.IsDeleted == false),
                Colors = _productColorService.GetAllProductColors(x => x.IsDeleted == false),

            };

            return View(shopVm);
        }



        public IActionResult Filter(string? search,decimal? minPrice, decimal? maxPrice, List<int> selectedBrands, List<int> selectedColors)
        {
			var products = _productService.GetAllProducts(x => x.IsDeleted == false).AsQueryable();

			if (search != null)
			{
				products = products.Where(x => x.Name.ToLower().Contains(search.ToLower()));
			}

			if (selectedBrands != null)
			{
				foreach(var item in selectedBrands)
				{
					products = products.Where(x => x.Brand.Id == item);
				}
				
			}

			if (selectedColors != null)
			{
				foreach (var item in selectedColors)
				{
					products = products.Where(x => x.ProductColor.Id == item);
				}
			}

			if(minPrice != null)
			{
				products = products = products.Where(x => x.Price >= minPrice); 
			}


			if (maxPrice != null)
			{
				products = products = products.Where(x => x.Price <= maxPrice); ;
			}



			List<ProductGetDTO> productGetDTOs = _mapper.Map<List<ProductGetDTO>>(products);

			ShopVm shopVm = new ShopVm
			{

				Brands = _brandService.GetAllBrands(x=> x.IsDeleted == false),
				Colors = _productColorService.GetAllProductColors(x => x.IsDeleted == false),
				Products = productGetDTOs


			};
			return View(shopVm);
		}
	}
}
