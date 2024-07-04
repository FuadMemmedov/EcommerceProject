using AutoMapper;
using Business.DTOs.CategoryDTOs;
using Business.DTOs.FaqDTOs;
using Business.Exceptions;
using Business.Extensions;
using Business.Service.Abstracts;
using Business.Service.Concretes;
using Core.Models;
using Data.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TechnoStore.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "SuperAdmin")]
	public class CategoryController : Controller
	{
		private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public IActionResult Index(int page = 1)
        {
            var categories = _categoryService.GetAllCategories(x => x.IsDeleted == false);
            List<Category> categoryGetDTOs = _mapper.Map<List<Category>>(categories);

            var paginatedDatas = PaginatedList<Category>.Create(categoryGetDTOs, 5, page);

            return View(paginatedDatas);
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
                ParentCategoryId = existCategory.ParentCategory?.Id
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
            var category = _categoryService.GetAllCategories(x => x.Id == id);
            if (category == null) return NotFound();
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

            var category = _categoryService.GetCategory(x => x.Id == id);
            if (category == null) return NotFound();
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

