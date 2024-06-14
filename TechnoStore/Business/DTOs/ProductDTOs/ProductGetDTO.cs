using Business.DTOs.CategoryDTOs;
using Core.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.ProductDTOs;

public class ProductGetDTO
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public string ShortDescription { get; set; }

	public decimal Price { get; set; }
	public decimal DiscountPercent { get; set; }
	public decimal CostPrice { get; set; }
	public Category Category { get; set; }
    public List<ProductImage>? ProductImages { get; set; }
    public List<int> ProductImageIds { get; set; }


}


