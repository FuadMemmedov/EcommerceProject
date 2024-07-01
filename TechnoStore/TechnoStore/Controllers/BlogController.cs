using AutoMapper;
using Business.DTOs.ProductDTOs;
using Business.Extensions;
using Business.Service.Abstracts;
using Business.Service.Concretes;
using Core.Models;
using Core.RepositoryAbstracts;
using Data.DAL;
using Microsoft.AspNetCore.Mvc;
using TechnoStore.ViewModels;

namespace TechnoStore.Controllers
{
	public class BlogController : Controller
	{
		private readonly IBlogService _blogService;
		private readonly IMapper _mapper;
		private readonly IBlogCategoryService _blogCategoryService;
		private readonly ITagService _tagService;
		public BlogController(IBlogService blogService, IMapper mapper, IBlogCategoryService blogCategoryService, ITagService tagService)
		{
			_blogService = blogService;
			_mapper = mapper;
			_blogCategoryService = blogCategoryService;
			_tagService = tagService;
		}

		public IActionResult Index(string? search,int page = 1)
		{

			var blogs = _blogService.GetAllBlogs(x => x.IsDeleted == false).AsQueryable();
			if (!string.IsNullOrEmpty(search))
			{
				blogs = blogs.Where(x => x.Title.ToLower().Contains(search.Trim().ToLower()));
											 
			}

			List<Blog> blogGetDTOs = _mapper.Map<List<Blog>>(blogs);

			//if (page <= 0 || page > (double)Math.Ceiling((double)blogGetDTOs.Count / 2))
			//{
			//	return RedirectToAction("Index", "ErrorPage");
			//}

			var paginatedDatas = PaginatedList<Blog>.Create(blogGetDTOs, 3, page);
            BlogVm blogVm = new BlogVm
            {

                PaginatedBlogs = paginatedDatas,
				BlogCategories = _blogCategoryService.GetAllBlogCategories(x=>x.IsDeleted == false),
				Tags = _tagService.GetAllTags(x=>x.IsDeleted == false)
            };

			return View(blogVm);
		}
		public IActionResult Detail(int id)
		{
			BlogVm blogVm = new BlogVm
			{

				Blog = _blogService.GetBlog(x => x.IsDeleted == false && x.Id == id)
			};

			return View(blogVm);
		}





	}

    
}

			
		
	

