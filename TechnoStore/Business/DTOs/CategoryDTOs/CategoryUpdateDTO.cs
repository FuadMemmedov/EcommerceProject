using Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.CategoryDTOs;

public class CategoryUpdateDTO
{
	public int Id { get; set; }
	public string Name { get; set; }
    public int? ParentCategoryId { get; set; }

	public ICollection<Category>? SubCategories { get; set; }
}

public class CategoryUpdateDTOValidator : AbstractValidator<CategoryUpdateDTO>
{
    public CategoryUpdateDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .NotNull().WithMessage("Name is required");

    }
}
