using Business.DTOs.BlogCategoryDTOs;
using Business.DTOs.BlogDTOs;
using Business.DTOs.TagDTOs;
using Business.Extensions;
using Core.Models;

namespace TechnoStore.ViewModels;

public class BlogVm
{
	public List<BlogGetDTO> Blogs = new List<BlogGetDTO>();
	public List<Category> Categories = new List<Category>();
	public BlogGetDTO Blog = new BlogGetDTO();
	public List<BlogCategoryGetDTO> BlogCategories = new List<BlogCategoryGetDTO>();
    public PaginatedList<Blog> PaginatedBlogs = new PaginatedList<Blog>();
	public List<TagGetDTO> Tags = new List<TagGetDTO>();
} 
