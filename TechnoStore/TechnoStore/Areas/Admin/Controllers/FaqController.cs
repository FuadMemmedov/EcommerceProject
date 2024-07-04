using AutoMapper;
using Business.DTOs.FaqDTOs;
using Business.DTOs.SliderDTOs;
using Business.Exceptions;
using Business.Extensions;
using Business.Service.Abstracts;
using Business.Service.Concretes;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TechnoStore.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "SuperAdmin")]
	public class FaqController : Controller
    {
        private readonly IFaqService _faqService;
        private readonly IMapper _mapper;

        public FaqController(IFaqService faqService, IMapper mapper)
        {
            _faqService = faqService;
            _mapper = mapper;
        }

        public IActionResult Index(int page = 1)
        {
            var faqs = _faqService.GetAllFaqs(x=> x.IsDeleted == false);
            List<Faq> faqGetDTOs = _mapper.Map<List<Faq>>(faqs);

            var paginatedDatas = PaginatedList<Faq>.Create(faqGetDTOs, 2, page);
            return View(paginatedDatas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FaqCreateDTO faqCreateDTO)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                await _faqService.AddFaqAsync(faqCreateDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var existFaq = _faqService.GetFaq(x => x.Id == id);

            if (existFaq == null) return NotFound();

            FaqUpdateDTO faqUpdateDTO = new FaqUpdateDTO
            {
                Id = existFaq.Id,
                Question = existFaq.Question,
                Answer = existFaq.Answer
            };




            return View(faqUpdateDTO);
        }

        [HttpPost]
        public IActionResult Update(FaqUpdateDTO faqUpdateDTO)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _faqService.UpdateFaq(faqUpdateDTO);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            try
            {
                _faqService.DeleteFaq(id);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
		public IActionResult SoftDelete(int id)
		{

            var faq = _faqService.GetFaq(x => x.Id == id);
            if (faq == null) return NotFound();
            try
			{
				_faqService.SoftDelete(id);
			}
			catch (EntityNotFoundException ex)
			{
				return NotFound();
			}

			return RedirectToAction("Index");
		}
        public IActionResult Return(int id)
        {
            var faq = _faqService.GetFaq(x => x.Id == id);
            if (faq == null) return NotFound();
            try
            {
                _faqService.ReturnFaq(id);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }


        public IActionResult Archive()
		{
			var faqs = _faqService.GetAllFaqs(x => x.IsDeleted == true);

			return View(faqs);
		}
	}
}
