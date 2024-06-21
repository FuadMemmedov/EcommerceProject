using Business.DTOs.BlogDTOs;
using Core.Models;

namespace TechnoStore.ViewModels;

public class BlogVm
{
	public List<BlogGetDTO> Blogs = new List<BlogGetDTO>();
	public List<Category> Categories = new List<Category>();
	public BlogGetDTO Blog = new BlogGetDTO();
}
