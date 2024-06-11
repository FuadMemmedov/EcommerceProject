using Business.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace TechnoStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;

        public HomeController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public IActionResult Index()
        {
            var sliders = _sliderService.GetAllSliders();
            return View(sliders);
        }





    }
}
