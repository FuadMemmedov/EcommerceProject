using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.SliderDTOs;

public class ShopSliderUpdateDTO
{
	public int Id { get; set; }
	public string Title { get; set; }
	public IFormFile? ImageFile { get; set; }
}
public class ShopSliderUpdateDTOValidator : AbstractValidator<ShopSliderUpdateDTO>
{
	public ShopSliderUpdateDTOValidator()
	{
		RuleFor(x => x.Title)
			.NotEmpty().WithMessage("Title is required")
			.NotNull().WithMessage("Title is required")
			.MaximumLength(100).WithMessage("Max length should be 100");

		



	}
}
