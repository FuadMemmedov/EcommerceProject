using Business.Service.Abstracts;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using Business.DTOs.SliderDTOs;
using Business.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace TechnoStore.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "SuperAdmin")]
	public class ContactInfoController : Controller
	{
		private readonly IContactPostService _contactPost;

		public ContactInfoController(IContactPostService contactPost)
		{
			_contactPost = contactPost;
		}

		public IActionResult Index(int page = 1)
		{

			var contacts = _contactPost.GetAllContactPosts(x => x.IsDeleted == false);

            var paginatedDatas = PaginatedList<ContactPost>.Create(contacts, 4, page);

            return View(paginatedDatas);
		}

		public IActionResult Reply(int id)
		{
			var existContac = _contactPost.GetContactPost(x => x.Id == id);
			if (existContac == null) return NotFound();

			return View(existContac);
		}
		[HttpPost] 
        public IActionResult Reply(ContactPost contactPost)
        {
			_contactPost.UpdateContactPost(contactPost);

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("memmedovfuad75@gmail.com","TechnoStore");
            mailMessage.To.Add(new MailAddress($"{contactPost.Email}"));
            mailMessage.Subject = $"Reply to {contactPost.Name}";
            mailMessage.Body = "Comment: " + $"\"{contactPost.Comment}\"" + "-" + " Answer:" + contactPost.Answer;
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("memmedovfuad75@gmail.com", "ibcxodjvmxfoilhu");
            smtpClient.Send(mailMessage);



            return RedirectToAction("index");
        }
    }
}
