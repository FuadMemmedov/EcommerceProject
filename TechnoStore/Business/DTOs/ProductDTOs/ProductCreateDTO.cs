using Core.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.ProductDTOs;

public class ProductCreateDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
	public string ShortDescription { get; set; }
	public decimal Price { get; set; }
    public decimal DiscountPercent { get; set; }
    public decimal CostPrice { get; set; }
    public IFormFile ProductPosterImageFile { get; set; }
    public List<IFormFile>? ImageFiles { get; set; }
    public int CategoryId { get; set; }
   
}
public class ProductCreateDTOValidator : AbstractValidator<ProductCreateDTO>
{
    public ProductCreateDTOValidator()
    {

        RuleFor(x => x).Custom((x, context) =>
        {
            if (x.CostPrice > x.Price)
            {
                context.AddFailure("CostPrice", "maya qiymeti satish qiymetinden baha ola bilmez!");
            }
        });
    }
}
