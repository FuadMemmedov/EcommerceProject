using Core.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.ProductDTOs;

public class ProductUpdateDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
	public string ShortDescription { get; set; }

	public decimal Price { get; set; }
    public decimal DiscountPercent { get; set; }
    public decimal CostPrice { get; set; }
    public int CategoryId { get; set; }
    public List<ProductImage>? ProductImages { get; set; }
    public IFormFile? ProductPosterImageFile { get; set; }
    public List<IFormFile>? ImageFiles { get; set; }

}
public class ProductUpdateDTOValidator : AbstractValidator<ProductUpdateDTO>
{
    public ProductUpdateDTOValidator()
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
