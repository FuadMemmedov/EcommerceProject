using Business.DTOs.FaqDTOs;
using Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.CategoryDTOs;

public class CategoryCreateDTO
{
	public string Name { get; set; }
	public int? ParentCategoryId { get; set; }
	
	
}

public class CategoryCreateDTOValidator : AbstractValidator<CategoryCreateDTO>
{
    public CategoryCreateDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .NotNull().WithMessage("Name is required");

    }
}
