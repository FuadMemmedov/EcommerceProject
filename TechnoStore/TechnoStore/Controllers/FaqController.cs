using Business.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace TechnoStore.Controllers
{
    public class FaqController : Controller
    {
        private readonly IFaqService _faqService;

        public FaqController(IFaqService faqService)
        {
            _faqService = faqService;
        }

        public IActionResult Index()
        {
            var faqs = _faqService.GetAllFaqs();
            return View(faqs);
        }
    }
}
