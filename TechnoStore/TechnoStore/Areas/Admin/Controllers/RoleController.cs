using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.IdentityModel.Tokens;
using TechnoStore.ViewModels;

namespace TechnoStore.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "SuperAdmin")]
	public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            if (role == null)
               return NotFound();

          
            await _roleManager.CreateAsync(role);
            return RedirectToAction("index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);


            if (role == null)
                return NotFound();

            await _roleManager.DeleteAsync(role);

            return Ok();


        }

		[HttpGet]
		public async Task<IActionResult> Update(string id)
		{
			var user = await _userManager.FindByIdAsync(id);
			if (user == null)
			{
				return NotFound();
			}

			var userRoles = await _userManager.GetRolesAsync(user);
			var allRoles = await _roleManager.Roles.ToListAsync();

			var model = new AdminRoleVm
			{
				User = user,
				Roles = allRoles,
				UserRoles = userRoles
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Update(string id, List<string> roles)
		{
			AppUser user = await _userManager.FindByIdAsync(id);
			if (user == null)
			{
				return NotFound();
			}

			var userRoles = await _userManager.GetRolesAsync(user);
			var resultRemove = await _userManager.RemoveFromRolesAsync(user, userRoles);
			if (!resultRemove.Succeeded)
			{
				ModelState.AddModelError("", "Failed to remove existing roles.");
				return View();
			}

			var resultAdd = await _userManager.AddToRolesAsync(user, roles);
			if (!resultAdd.Succeeded)
			{
				ModelState.AddModelError("", "Failed to add new roles.");
				return View();
			}

			return RedirectToAction("Index", "User");
		}
	}
}
