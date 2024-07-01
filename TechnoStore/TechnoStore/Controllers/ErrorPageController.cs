using Microsoft.AspNetCore.Mvc;

namespace TechnoStore.Controllers
{
	public class ErrorPageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
