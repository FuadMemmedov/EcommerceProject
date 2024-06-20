﻿using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.TeamDTOs;

public class TeamCreateDTO
{
	public string FullName { get; set; }
	public string Designation { get; set; }
	public IFormFile ImageFile { get; set; }
}

public class TeamCreateDTOValidator : AbstractValidator<TeamCreateDTO>
{
    public TeamCreateDTOValidator()
    {
		RuleFor(x => x.FullName)
			.NotEmpty().WithMessage("FullName is required")
			.NotNull().WithMessage("FullName is required");

		RuleFor(x => x.Designation)
			.NotEmpty().WithMessage("Designation is required")
			.NotNull().WithMessage("Designation is required");
	}
}
