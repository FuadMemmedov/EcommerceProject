using Business.DTOs.CategoryDTOs;
using Business.Exceptions;
using Business.Service.Abstracts;
using Business.Service.Concretes;
using Data.DAL;
using Microsoft.AspNetCore.Mvc;

namespace TechnoStore.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public IActionResult Index()
		{
			var categories = _categoryService.GetAllCategories();
			return View(categories);
		}
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CategoryCreateDTO categoryCreateDTO)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			await _categoryService.AddCategoryAsync(categoryCreateDTO);
			return RedirectToAction("Index");
		}
		public IActionResult Delete(int id)
		{
			try
			{
				_categoryService.DeleteCategory(id);
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
