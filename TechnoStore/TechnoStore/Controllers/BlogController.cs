using AutoMapper;
using Business.Extensions;
using Business.Service.Abstracts;
using Business.Service.Concretes;
using Core.Models;
using Data.DAL;
using Microsoft.AspNetCore.Mvc;
using TechnoStore.ViewModels;

namespace TechnoStore.Controllers
{
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

			
		
	

