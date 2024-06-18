using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TechnoStore.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UserController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public UserController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public IActionResult Index(string search)
		{
			var users = search == null ? _userManager.Users.ToList() : _userManager.Users.Where(u => u.Name.Contains(search)).ToList();

			

			return View(users);
		}

		public async Task<IActionResult> Delete(string id)
		{
			var user = await _userManager.FindByIdAsync(id);


			if (user == null)
			return NotFound();

			await _userManager.DeleteAsync(user);

			return Ok();

					
		}
	}
}
