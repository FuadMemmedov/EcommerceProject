using Core.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.BlogDTOs;

public class BlogUpdateDTO
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }

	public IFormFile? ImageFile { get; set; }
}

public class BlogUpdateDTOValidator : AbstractValidator<BlogUpdateDTO>
{
	public BlogUpdateDTOValidator()
	{
		RuleFor(x => x.Title)
		 .NotEmpty().WithMessage("Title is required")
		 .NotNull().WithMessage("Title is required");

		RuleFor(x => x.Description)
		 .NotEmpty().WithMessage("Description is required")
		 .NotNull().WithMessage("Description is required");
		
	}
}
