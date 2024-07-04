using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.SliderDTOs;

public class SliderCreateDTO
{
	public string Title { get; set; }
	public decimal Price { get; set; }
	public int? DiscountPercent { get; set; }
	public string RedirectUrl { get; set; }
	public IFormFile ImageFile { get; set; }

}

public class SliderCreateDTOValidator:AbstractValidator<SliderCreateDTO>
{
    public SliderCreateDTOValidator()
    {
		RuleFor(x => x.Title)
			.NotEmpty().WithMessage("Title is required")
			.NotNull().WithMessage("Title is required")
			.MaximumLength(100).WithMessage("Max length should be 100");

		RuleFor(x => x.Price)
			.NotEmpty().WithMessage("Price is required")
			.NotNull().WithMessage("Price is required");

	



	}
}
