using Microsoft.AspNetCore.Mvc;

namespace TechnoStore.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
