using Business.Service.Abstracts;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Xml.Linq;

namespace TechnoStore.Controllers
{
	public class ContactController : Controller
	{
		private readonly IContactPostService _contactPostService;


		public ContactController(IContactPostService contactPostService)
		{
			_contactPostService = contactPostService;
		}

		public IActionResult Index()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Index(ContactPost contactPost)
		{
			if (!ModelState.IsValid)
				return View();

			await _contactPostService.AddContactPostAsync(contactPost);

			ModelState.Clear();




			return View();
		}
	}

       
}
