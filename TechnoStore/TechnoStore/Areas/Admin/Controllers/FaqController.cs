﻿using Business.DTOs.FaqDTOs;
using Business.DTOs.SliderDTOs;
using Business.Exceptions;
using Business.Service.Abstracts;
using Business.Service.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace TechnoStore.Areas.Admin.Controllers
{
    [Area("Admin")]
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
    }
}
