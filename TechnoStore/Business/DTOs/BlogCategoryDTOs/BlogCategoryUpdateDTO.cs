using Business.DTOs.BrandDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.BlogCategoryDTOs;

public class BlogCategoryUpdateDTO
{
	public int Id { get; set; }
	public string Name { get; set; }
}
public class BlogCategoryUpdateDTOValidator : AbstractValidator<BlogCategoryUpdateDTO>
{
	public BlogCategoryUpdateDTOValidator()
	{
		RuleFor(x => x.Name)
		 .NotEmpty().WithMessage("Name is required")
		 .NotNull().WithMessage("Name is required");
	}
}
