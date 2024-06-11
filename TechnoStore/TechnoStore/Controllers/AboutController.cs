using Microsoft.AspNetCore.Mvc;

namespace TechnoStore.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
