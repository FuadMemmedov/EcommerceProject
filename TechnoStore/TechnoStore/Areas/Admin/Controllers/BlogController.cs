using AutoMapper;
using Business.DTOs.BlogDTOs;
using Business.Exceptions;
using Business.Extensions;
using Business.Service.Abstracts;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace TechnoStore.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class BlogController : Controller
	{
		private readonly IBlogService _blogService;
		private readonly IMapper _mapper;


		public BlogController(IBlogService blogService, IMapper mapper)
		{
			_blogService = blogService;
			_mapper = mapper;
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
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(BlogCreateDTO blogCreateDTO)
		{
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
				Description = existBlog.Description
			};




			return View(blogUpdateDTO);
		}

		[HttpPost]
		public IActionResult Update(BlogUpdateDTO blogUpdateDTO)
		{
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
			try
			{
				_blogService.SoftDelete(id);
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
				_blogService.ReturnBlog(id);
			}
			catch (EntityNotFoundException ex)
			{
				return NotFound();
			}

			return RedirectToAction("Index");
		}

		public IActionResult Archive()
		{
			var blogs = _blogService.GetAllBlogs(x => x.IsDeleted == true);

			return View(blogs);
		}
	}
}
