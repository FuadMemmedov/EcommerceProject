using Business.DTOs.BrandDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.BlogCategoryDTOs;

public class BlogCategoryCreateDTO
{
	public string Name { get; set; }
}
public class BlogCategoryCreateDTOValidator : AbstractValidator<BlogCategoryCreateDTO>
{
	public BlogCategoryCreateDTOValidator()
	{
		RuleFor(x => x.Name)
		 .NotEmpty().WithMessage("Name is required")
		 .NotNull().WithMessage("Name is required");
	}
}
