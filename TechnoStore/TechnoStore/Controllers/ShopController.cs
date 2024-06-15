using Business.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;
using TechnoStore.ViewModels;

namespace TechnoStore.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopSliderService _shopSliderService;
        private readonly IProductService _productService;
        private readonly IProductColorService _productColorService;

		public ShopController(IShopSliderService shopSliderService, IProductService productService, IProductColorService productColorService)
		{
			_shopSliderService = shopSliderService;
			_productService = productService;
			_productColorService = productColorService;
		}

		public IActionResult Index()
        {
            var shopSliders = _shopSliderService.GetAllShopSliders();
            return View(shopSliders);
        }


        public IActionResult Detail(int id)
        {
            HomeVm homeVm = new HomeVm
            {

                Product = _productService.GetProduct(x => x.Id == id && x.IsDeleted == false),
                Colors = _productColorService.GetAllProductColors(x => x.IsDeleted == false)

            };

            return View(homeVm);
        }
    }
}
