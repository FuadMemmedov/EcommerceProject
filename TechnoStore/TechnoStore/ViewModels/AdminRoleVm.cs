using Core.Models;
using Microsoft.AspNetCore.Identity;

namespace TechnoStore.ViewModels
{
    public class AdminRoleVm
    {
        public List<IdentityRole> Roles { get; set; }

        public IList<string> UserRoles { get; set; }
        public AppUser User { get; set; }
    }
}
