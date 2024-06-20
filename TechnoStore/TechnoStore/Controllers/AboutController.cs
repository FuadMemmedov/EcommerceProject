using Business.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;
using TechnoStore.ViewModels;

namespace TechnoStore.Controllers
{
    public class AboutController : Controller
    {
        private readonly ITeamService _teamService;

        public AboutController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            AboutVm aboutVm = new AboutVm
            {
                Teams = _teamService.GetAllTeams(x=> x.IsDeleted == false)
            };
            return View(aboutVm);
        }
    }
}
