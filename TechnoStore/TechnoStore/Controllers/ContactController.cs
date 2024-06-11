using Microsoft.AspNetCore.Mvc;

namespace TechnoStore.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
