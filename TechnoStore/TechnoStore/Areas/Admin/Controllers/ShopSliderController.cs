using Business.DTOs.SliderDTOs;
using Business.Exceptions;
using Business.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace TechnoStore.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ShopSliderController : Controller
	{
		private readonly IShopSliderService _shopSliderService;

		public ShopSliderController(IShopSliderService shopSliderService)
		{
			_shopSliderService = shopSliderService;
		}

		public IActionResult Index()
		{
			var sliders = _shopSliderService.GetAllShopSliders();
			return View(sliders);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(ShopSliderCreateDTO sliderCreateDTO)
		{
			if (!ModelState.IsValid)
				return View();

			try
			{
				await _shopSliderService.AddShopSliderAsync(sliderCreateDTO);
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
			var existSlider = _shopSliderService.GetShopSlider(x => x.Id == id);

			if (existSlider == null) return NotFound();

			ShopSliderUpdateDTO sliderUpdateDTO = new ShopSliderUpdateDTO
			{
				Id = existSlider.Id,
				Title = existSlider.Title,
			};




			return View(sliderUpdateDTO);
		}

		[HttpPost]
		public IActionResult Update(ShopSliderUpdateDTO sliderUpdateDTO)
		{
			if (!ModelState.IsValid)
				return View();

			try
			{
				_shopSliderService.UpdateShopSlider(sliderUpdateDTO);
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
				_shopSliderService.DeleteShopSlider(id);
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
