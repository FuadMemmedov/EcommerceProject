using Business.DTOs.CategoryDTOs;
using Business.DTOs.SliderDTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Abstracts;

public interface ICategoryService
{
	Task AddCategoryAsync(CategoryCreateDTO categoryCreateDTO);
	void DeleteCategory(int id);
	void UpdateCategory(CategoryUpdateDTO updateDTO);
	CategoryGetDTO GetCategory(Func<Category, bool>? func = null,params string[]? includes);
	List<CategoryGetDTO> GetAllCategories(Func<Category, bool>? func = null, params string[]? includes);
}
