using AutoMapper;
using Business.DTOs.BlogDTOs;
using Business.DTOs.CategoryDTOs;
using Business.Exceptions;
using Business.Extensions;
using Business.Service.Abstracts;
using Core.Models;
using Core.RepositoryAbstracts;
using Data.RepositoryConcretes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Concretes;

public class CategoryService : ICategoryService
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly IMapper _mapper;
	private readonly IWebHostEnvironment _env;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IWebHostEnvironment env)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _env = env;
    }


    public List<CategoryGetDTO> GetAllCategories(Func<Category, bool>? func = null)
	{
		var categories =  _categoryRepository.GetAllEntities(func, "SubCategories");
		List<CategoryGetDTO> categoryGetDTOs = _mapper.Map<List<CategoryGetDTO>>(categories);

		return categoryGetDTOs;
	}

	public CategoryGetDTO GetCategory(Func<Category, bool>? func = null)
	{
		var category =  _categoryRepository.GetEntity(func, "SubCategories");
		CategoryGetDTO categoryGetDTO = _mapper.Map<CategoryGetDTO>(category);
		return categoryGetDTO;
	}

	public async Task AddCategoryAsync(CategoryCreateDTO categoryDto)
	{
		if(categoryDto.ParentCategoryId != null)
		{
			var existCategory = _categoryRepository.GetEntity(x => x.Id == categoryDto.ParentCategoryId);
			if (existCategory == null) throw new EntityNotFoundException("Category not found!");
        }
        Category category = _mapper.Map<Category>(categoryDto);
		if(categoryDto.IconFile != null)
		{
         category.IconUrl = Helper.SaveFile(_env.WebRootPath, @"uploads/categories", categoryDto.IconFile, "categoryIcon");

		}

        await _categoryRepository.AddEntityAsync(category);
		await _categoryRepository.CommitAsync();
	}

	public void UpdateCategory(CategoryUpdateDTO categoryDto)
	{
		var oldCategory = _categoryRepository.GetEntity(x => x.Id == categoryDto.Id);
		if (oldCategory == null) throw new EntityNotFoundException("Category not found");
        if (categoryDto.ParentCategoryId != null)
        {
            var existCategory = _categoryRepository.GetEntity(x => x.Id == categoryDto.ParentCategoryId);
            if (existCategory == null) throw new EntityNotFoundException("Category not found!");
        }
		if (categoryDto.IconFile != null)
		{
			Category category = _mapper.Map<Category>(categoryDto);
			category.IconUrl = Helper.SaveFile(_env.WebRootPath, @"uploads/categories", categoryDto.IconFile, "categoryIcon");
			if (oldCategory.IconUrl != null)
			{
            Helper.DeleteFile(_env.WebRootPath, @"uploads\categories", oldCategory.IconUrl);

			}

            oldCategory.IconUrl = category.IconUrl;
        }

		oldCategory.Name = categoryDto.Name;
		oldCategory.ParentCategoryId = categoryDto.ParentCategoryId;

		oldCategory.UpdatedDate = DateTime.UtcNow.AddHours(4);

		_categoryRepository.Commit();
		
	}


	public void DeleteCategory(int id)
	{
        var existCategory = _categoryRepository.GetEntity(x => x.Id == id);
        if (existCategory == null) throw new EntityNotFoundException("Category not found");

        if(existCategory.IconUrl != null)
		{
			Helper.DeleteFile(_env.WebRootPath, @"uploads\categories", existCategory.IconUrl);
		}

        _categoryRepository.DeleteEntity(existCategory);
		_categoryRepository.Commit();
    }

	public void SoftDelete(int id)
	{
        var existCategory = _categoryRepository.GetEntity(x => x.Id == id);
        if (existCategory == null) throw new EntityNotFoundException("Category not found!");
        existCategory.DeletedDate = DateTime.UtcNow.AddHours(4);

        _categoryRepository.SoftDelete(existCategory);

        _categoryRepository.Commit();
    }

	public void ReturnCategory(int id)
	{
        var existFaq = _categoryRepository.GetEntity(x => x.Id == id);
        if (existFaq == null) throw new EntityNotFoundException("category not found!");

        _categoryRepository.ReturnEntity(existFaq);

        _categoryRepository.Commit();
    }
}




