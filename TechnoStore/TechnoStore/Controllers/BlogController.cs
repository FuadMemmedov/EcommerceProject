using Microsoft.AspNetCore.Mvc;

namespace TechnoStore.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
