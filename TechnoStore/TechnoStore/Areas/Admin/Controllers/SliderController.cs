using AutoMapper;
using Business.DTOs.SliderDTOs;
using Business.Exceptions;
using Business.Service.Abstracts;
using Core.Models;
using Data.DAL;
using Microsoft.AspNetCore.Mvc;

namespace TechnoStore.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SliderController : Controller
	{

        private readonly ISliderService _sliderService;
     

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public IActionResult Index()
		{
            var sliders = _sliderService.GetAllSliders();
			return View(sliders);
		}

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SliderCreateDTO sliderCreateDTO)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                await _sliderService.AddSliderAsync(sliderCreateDTO);
            }
            catch (FileContentTypeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (FileSizeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (EntityFileNotFoundException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var existSlider = _sliderService.GetSlider(x => x.Id == id);

            if (existSlider == null) return NotFound();

           SliderUpdateDTO sliderUpdateDTO = new SliderUpdateDTO
            {
                Id = existSlider.Id,
                Title = existSlider.Title,
                Price = existSlider.Price,
                DiscountPrice = existSlider.DiscountPrice,
                RedirectUrl = existSlider.RedirectUrl
            };




            return View(sliderUpdateDTO);
        }

        [HttpPost]
        public IActionResult Update(SliderUpdateDTO sliderUpdateDTO)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _sliderService.UpdateSlider(sliderUpdateDTO);
            }
            catch (FileContentTypeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (FileSizeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
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
                _sliderService.DeleteSlider(id);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (EntityFileNotFoundException ex)
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

