using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.FaqDTOs;

public class FaqUpdateDTO
{
    public int Id { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
}
public class FaqUpdateDTOValidator : AbstractValidator<FaqUpdateDTO>
{
    public FaqUpdateDTOValidator()
    {
        RuleFor(x => x.Question)
            .NotEmpty().WithMessage("Question is required")
            .NotNull().WithMessage("Question is required");

        RuleFor(x => x.Answer)
           .NotEmpty().WithMessage("Answer is required")
             .NotNull().WithMessage("Answer is required");
    }
}

