using AutoMapper;
using Business.DTOs.CategoryDTOs;
using Business.Exceptions;
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

public class CategoryService : ICategoryService
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly IMapper _mapper;

	public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
	{
		_categoryRepository = categoryRepository;
		_mapper = mapper;
	}

	public  async Task AddCategoryAsync(CategoryCreateDTO categoryCreateDTO)
	{
		if (!_categoryRepository.GetAllEntities().Any(x => x.Name == categoryCreateDTO.Name))
		{
			
			Category category = _mapper.Map<Category>(categoryCreateDTO);

			await _categoryRepository.AddEntityAsync(category);
			await _categoryRepository.CommitAsync();
		}
		else
		{
			throw new DuplicateCategoryException("Category  cannot be repeated");
		}
	}

	public void DeleteCategory(int id)
	{
		var existCategory = _categoryRepository.GetEntity(x => x.Id == id);
		if (existCategory == null) throw new EntityNotFoundException("Category not found");

		_categoryRepository.DeleteEntity(existCategory);
		_categoryRepository.Commit();
	}

	public List<CategoryGetDTO> GetAllCategories(Func<Category, bool>? func = null, params string[]? includes)
	{
		var categories = _categoryRepository.GetAllEntities(func);
		List<CategoryGetDTO> categoryGetDTOs = _mapper.Map<List<CategoryGetDTO>>(categories);

		return categoryGetDTOs;
	}

	public CategoryGetDTO GetCategory(Func<Category, bool>? func = null, params string[]? includes)
	{
		var categories = _categoryRepository.GetEntity(func);
		CategoryGetDTO categoryGetDTOs = _mapper.Map<CategoryGetDTO>(categories);

		return categoryGetDTOs;
	}

    public void ReturnCategoryd(int id)
    {
        var existCategory = _categoryRepository.GetEntity(x => x.Id == id);
        if (existCategory == null) throw new EntityNotFoundException("Category not found!");


        _categoryRepository.ReturnEntity(existCategory);

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

	public void UpdateCategory(CategoryUpdateDTO updateDTO)
	{
		var existCategory = _categoryRepository.GetEntity(x => x.Id == updateDTO.Id);
		throw new EntityNotFoundException("Category not found!");

		if (!_categoryRepository.GetAllEntities().Any(x => x.Name == updateDTO.Name && x.Id != updateDTO.Id ))
			throw new DuplicateCategoryException("Category  cannot be repeated");




		_categoryRepository.Commit();
	}
}
