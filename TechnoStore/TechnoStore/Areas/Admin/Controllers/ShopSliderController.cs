using AutoMapper;
using Business.DTOs.SliderDTOs;
using Business.Exceptions;
using Business.Extensions;
using Business.Service.Abstracts;
using Business.Service.Concretes;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace TechnoStore.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ShopSliderController : Controller
	{
		private readonly IShopSliderService _shopSliderService;
		private readonly IMapper _mapper;

        public ShopSliderController(IShopSliderService shopSliderService, IMapper mapper)
        {
            _shopSliderService = shopSliderService;
            _mapper = mapper;
        }

        public IActionResult Index(int page = 1)
		{
			var sliders = _shopSliderService.GetAllShopSliders(x => x.IsDeleted == false);
            List<ShopSlider> shopSliderGetDTOs = _mapper.Map<List<ShopSlider>>(sliders);

            var paginatedDatas = PaginatedList<ShopSlider>.Create(shopSliderGetDTOs, 2, page);
            return View(paginatedDatas);
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

		public IActionResult SoftDelete(int id)
		{
			try
			{
				_shopSliderService.SoftDelete(id);
			}
			catch (EntityNotFoundException ex)
			{
				return NotFound();
			}

			return RedirectToAction("Index");
		}
        public IActionResult Return(int id)
        {
            try
            {
                _shopSliderService.ReturnShopSlider(id);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Archive()
		{
			var shopsliders = _shopSliderService.GetAllShopSliders(x => x.IsDeleted == true);

			return View(shopsliders);
		}
	}
}
