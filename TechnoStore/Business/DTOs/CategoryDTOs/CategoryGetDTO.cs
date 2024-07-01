using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.CategoryDTOs;

public class CategoryGetDTO
{
	public int Id { get; set; }
	public string Name { get; set; }

	public Category? ParentCategory { get; set; }

	public ICollection<Category>? SubCategories { get; set; }


}
