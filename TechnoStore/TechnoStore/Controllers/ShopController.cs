using Business.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace TechnoStore.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopSliderService _shopSliderService;

        public ShopController(IShopSliderService shopSliderService)
        {
            _shopSliderService = shopSliderService;
        }

        public IActionResult Index()
        {
            var shopSliders = _shopSliderService.GetAllShopSliders();
            return View(shopSliders);
        }
    }
}
