using AutoMapper;
using Business.DTOs.BlogDTOs;
using Business.Exceptions;
using Business.Extensions;
using Business.Service.Abstracts;
using Business.Service.Concretes;
using Core.Models;
using Data.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TechnoStore.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "SuperAdmin")]
	public class BlogController : Controller
	{
		private readonly IBlogService _blogService;
		private readonly IMapper _mapper;
		private readonly ITagService _tagService;
		private readonly IBlogCategoryService _blogCategoryService;


		public BlogController(IBlogService blogService, IMapper mapper, ITagService tagService, IBlogCategoryService blogCategoryService)
		{
			_blogService = blogService;
			_mapper = mapper;
			_tagService = tagService;
			_blogCategoryService = blogCategoryService;
		}

		public IActionResult Index(int page = 1)
		{
			var blogs = _blogService.GetAllBlogs(x => x.IsDeleted == false);
			List<Blog> blogGetDTOs = _mapper.Map<List<Blog>>(blogs);

			var paginatedDatas = PaginatedList<Blog>.Create(blogGetDTOs, 3, page);
			return View(paginatedDatas);
		}

		public IActionResult Create()
		{
            ViewBag.Tags = _tagService.GetAllTags(x=> x.IsDeleted == false);
			ViewBag.BlogCategories = _blogCategoryService.GetAllBlogCategories(x => x.IsDeleted == false);
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(BlogCreateDTO blogCreateDTO)
		{

            ViewBag.Tags = _tagService.GetAllTags(x => x.IsDeleted == false);
			ViewBag.BlogCategories = _blogCategoryService.GetAllBlogCategories(x => x.IsDeleted == false);
			if (!ModelState.IsValid)
				return View();

			try
			{
				await _blogService.AddBlogAsync(blogCreateDTO);
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
			var existBlog = _blogService.GetBlog(x => x.Id == id);

			if (existBlog == null) return NotFound();

			BlogUpdateDTO blogUpdateDTO = new BlogUpdateDTO
			{
				Id = existBlog.Id,
				Title = existBlog.Title,
				Description = existBlog.Description,
				BlogCategoryId = existBlog.BlogCategory.Id
			};

            ViewBag.Tags = _tagService.GetAllTags(x => x.IsDeleted == false);
			ViewBag.BlogCategories = _blogCategoryService.GetAllBlogCategories(x => x.IsDeleted == false);


			return View(blogUpdateDTO);
		}

		[HttpPost]
		public IActionResult Update(BlogUpdateDTO blogUpdateDTO)
		{

            ViewBag.Tags = _tagService.GetAllTags(x => x.IsDeleted == false);
			ViewBag.BlogCategories = _blogCategoryService.GetAllBlogCategories(x => x.IsDeleted == false);
			if (!ModelState.IsValid)
				return View();

			try
			{
				_blogService.UpdateBlog(blogUpdateDTO);
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
				_blogService.DeleteBlog(id);
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
            var blog = _blogService.GetAllBlogs(x => x.Id == id);
            if (blog == null) return NotFound();

            _blogService.SoftDelete(id);
			
			

			return RedirectToAction("Index");
		}
		public IActionResult Return(int id)
		{

            var blog = _blogService.GetAllBlogs(x => x.Id == id);
            if (blog == null) return NotFound();
           	
			_blogService.ReturnBlog(id);
			

			return RedirectToAction("Index");
		}

		public IActionResult Archive()
		{
			var blogs = _blogService.GetAllBlogs(x => x.IsDeleted == true);

			return View(blogs);
		}
	}
}
