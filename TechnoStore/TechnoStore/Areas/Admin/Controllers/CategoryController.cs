using Business.DTOs.CategoryDTOs;
using Business.DTOs.FaqDTOs;
using Business.Exceptions;
using Business.Service.Abstracts;
using Business.Service.Concretes;
using Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var categories = _categoryService.GetAllCategories(x => x.IsDeleted == false);
            return View(categories);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _categoryService.GetAllCategories(x => x.IsDeleted == false);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDTO categoryCreateDTO)
        {

            ViewBag.Categories = _categoryService.GetAllCategories(x => x.IsDeleted == false);
            if (!ModelState.IsValid)
                return View();

            try
            {
                await _categoryService.AddCategoryAsync(categoryCreateDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            ViewBag.Categories = _categoryService.GetAllCategories(x => x.IsDeleted == false);
            var existCategory = _categoryService.GetCategory(x => x.Id == id);

            if (existCategory == null) return NotFound();

            CategoryUpdateDTO categoryUpdate = new CategoryUpdateDTO
            {
                Id = existCategory.Id,
                Name = existCategory.Name,
                ParentCategoryId = existCategory.ParentCategory.Id
            };




            return View(categoryUpdate);
        }

        [HttpPost]
        public IActionResult Update(CategoryUpdateDTO categoryUpdateDTO)
        {

            ViewBag.Categories = _categoryService.GetAllCategories(x => x.IsDeleted == false);
            if (!ModelState.IsValid)
                return View();

            try
            {
                _categoryService.UpdateCategory(categoryUpdateDTO);
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
                _categoryService.DeleteCategory(id);
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
            try
            {
                _categoryService.SoftDelete(id);
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
                _categoryService.ReturnCategory(id);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }


        public IActionResult Archive()
        {
            var faqs = _categoryService.GetAllCategories(x => x.IsDeleted == true);

            return View(faqs);
        }

    }

}

