using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.IdentityModel.Tokens;
using TechnoStore.ViewModels;

namespace TechnoStore.Areas.Admin.Controllers
{
    [Area("Admin")]
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

        public async Task<IActionResult> Update(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            AdminRoleVm adminRoleVm = new AdminRoleVm();
            adminRoleVm.UserRoles = await _userManager.GetRolesAsync(user);
            adminRoleVm.Roles =  _roleManager.Roles.ToList();
            adminRoleVm.User = user;

            return View(adminRoleVm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(string id,List<string> roles)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
           var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user,userRoles);
            await _userManager.AddToRolesAsync(user, roles);


          
            return RedirectToAction("index","user");
        }
    }
}
