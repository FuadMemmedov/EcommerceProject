using AutoMapper;
using Business.DTOs.BlogCategoryDTOs;
using Business.Exceptions;
using Business.Extensions;
using Business.Service.Abstracts;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TechnoStore.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles ="SuperAdmin")]
	public class BlogCategoryController : Controller
	{
		private readonly IBlogCategoryService _blogCategoryService;
		private readonly IMapper _mapper;

		public BlogCategoryController(IBlogCategoryService blogCategoryService, IMapper mapper)
		{
			_blogCategoryService = blogCategoryService;
			_mapper = mapper;
		}

		public IActionResult Index(int page = 1)
		{

			var blogCategories = _blogCategoryService.GetAllBlogCategories(x => x.IsDeleted == false);
			List<BlogCategory> blogCategoryGetDTOs = _mapper.Map<List<BlogCategory>>(blogCategories);

			var paginatedDatas = PaginatedList<BlogCategory>.Create(blogCategoryGetDTOs, 2, page);
			return View(paginatedDatas);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(BlogCategoryCreateDTO blogCategoryCreateDTO)
		{
			if (!ModelState.IsValid)
				return View();

			try
			{
			await _blogCategoryService.AddBlogCategoryAsync(blogCategoryCreateDTO);

			}
			catch (DuplicateCategoryException ex)
			{
				ModelState.AddModelError("Name", ex.Message);
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
			var existBlogCategory = _blogCategoryService.GetBlogCategory(x => x.Id == id);

			if (existBlogCategory == null) return NotFound();

			BlogCategoryUpdateDTO BlogCategoryUpdateDTO = new BlogCategoryUpdateDTO
			{
				Name = existBlogCategory.Name
			};




			return View(BlogCategoryUpdateDTO);
		}

		[HttpPost]
		public IActionResult Update(BlogCategoryUpdateDTO blogCategoryUpdateDTO)
		{
			if (!ModelState.IsValid)
				return View();

			try
			{
				_blogCategoryService.UpdateBlogCategory(blogCategoryUpdateDTO);
			}
			catch (EntityNotFoundException ex)
			{
				return NotFound();
			}
            catch (DuplicateCategoryException ex)
            {
                ModelState.AddModelError("Name", ex.Message);
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
				_blogCategoryService.DeleteBlogCategory(id);
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
			var blogCategory = _blogCategoryService.GetBlogCategory(x => x.Id == id);
			if (blogCategory == null) return NotFound();
				
			_blogCategoryService.SoftDelete(id);
			
			

			return RedirectToAction("Index");
		}
		public IActionResult Return(int id)
		{
            var blogCategory = _blogCategoryService.GetBlogCategory(x => x.Id == id);
            if (blogCategory == null) return NotFound();

            _blogCategoryService.ReturnBlogCategory(id);
			
			

			return RedirectToAction("Index");
		}


		public IActionResult Archive()
		{
			var blogCategories = _blogCategoryService.GetAllBlogCategories(x => x.IsDeleted == true);

			return View(blogCategories);
		}
	}
}
