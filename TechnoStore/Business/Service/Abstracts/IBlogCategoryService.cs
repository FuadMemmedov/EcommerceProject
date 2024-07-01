using Business.DTOs.BlogCategoryDTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Abstracts;

public interface IBlogCategoryService
{
	Task AddBlogCategoryAsync(BlogCategoryCreateDTO blogCategoryCreateDTO);
	void DeleteBlogCategory(int id);
	void SoftDelete(int id);
	void ReturnBlogCategory(int id);
	void UpdateBlogCategory(BlogCategoryUpdateDTO updateDTO);
	BlogCategoryGetDTO GetBlogCategory(Func<BlogCategory, bool>? func = null);
	List<BlogCategoryGetDTO> GetAllBlogCategories(Func<BlogCategory, bool>? func = null);
}
