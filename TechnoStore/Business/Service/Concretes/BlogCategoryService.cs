using AutoMapper;
using Business.DTOs.BlogCategoryDTOs;
using Business.Exceptions;
using Business.Extensions;
using Business.Service.Abstracts;
using Core.Models;
using Core.RepositoryAbstracts;
using Data.RepositoryConcretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Concretes;

public class BlogCategoryService:IBlogCategoryService
{
	private readonly IBlogCategoryRepository _blogCategory;
	private readonly IMapper _mapper;
	public BlogCategoryService(IBlogCategoryRepository blogCategory, IMapper mapper)
	{
		_blogCategory = blogCategory;
		_mapper = mapper;
	}


	public async Task AddBlogCategoryAsync(BlogCategoryCreateDTO BlogCategoryCreateDTO)
	{
		BlogCategory BlogCategory = _mapper.Map<BlogCategory>(BlogCategoryCreateDTO);

		

		await _blogCategory.AddEntityAsync(BlogCategory);
		await _blogCategory.CommitAsync();
	}

	public void DeleteBlogCategory(int id)
	{
		var existBlogCategory = _blogCategory.GetEntity(x => x.Id == id);
		if (existBlogCategory == null) throw new EntityNotFoundException("BlogCategory not found");

		



		_blogCategory.DeleteEntity(existBlogCategory);
		_blogCategory.Commit();
	}

	public List<BlogCategoryGetDTO> GetAllBlogCategories(Func<BlogCategory, bool>? func = null)
	{
		var BlogCategorys = _blogCategory.GetAllEntities(func);
		List<BlogCategoryGetDTO> BlogCategoryGetDTOs = _mapper.Map<List<BlogCategoryGetDTO>>(BlogCategorys);


		return BlogCategoryGetDTOs;
	}

	public BlogCategoryGetDTO GetBlogCategory(Func<BlogCategory, bool>? func = null)
	{
		var BlogCategory = _blogCategory.GetEntity(func);
		BlogCategoryGetDTO BlogCategoryGetDTOs = _mapper.Map<BlogCategoryGetDTO>(BlogCategory);


		return BlogCategoryGetDTOs;
	}

	public void ReturnBlogCategory(int id)
	{
		var existBlogCategory = _blogCategory.GetEntity(x => x.Id == id);
		if (existBlogCategory == null) throw new EntityNotFoundException("BlogCategory not found!");


		_blogCategory.ReturnEntity(existBlogCategory);

		_blogCategory.Commit();
	}

	public void SoftDelete(int id)
	{
		var existBlogCategory = _blogCategory.GetEntity(x => x.Id == id);
		if (existBlogCategory == null) throw new EntityNotFoundException("BlogCategory not found!");

		existBlogCategory.DeletedDate = DateTime.UtcNow.AddHours(4);
		_blogCategory.SoftDelete(existBlogCategory);

		_blogCategory.Commit();
	}

	public void UpdateBlogCategory(BlogCategoryUpdateDTO updateDTO)
	{
		var oldBlogCategory = _blogCategory.GetEntity(x => x.Id == updateDTO.Id);
		if (oldBlogCategory == null) throw new EntityNotFoundException("BlogCategory not found");

		

		oldBlogCategory.Name = updateDTO.Name;
		oldBlogCategory.UpdatedDate = DateTime.UtcNow.AddHours(4);


		_blogCategory.Commit();
	}
}
