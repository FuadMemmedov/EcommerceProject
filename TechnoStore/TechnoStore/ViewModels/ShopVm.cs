using Business.DTOs.BrandDTOs;
using Business.DTOs.CategoryDTOs;
using Business.DTOs.ProductColorDTOs;
using Business.DTOs.ProductDTOs;
using Business.DTOs.SliderDTOs;
using Business.Extensions;
using Core.Models;

namespace TechnoStore.ViewModels;

public class ShopVm
{
	public List<ProductColorGetDTO> Colors = new List<ProductColorGetDTO>();
	public ProductGetDTO Product = new ProductGetDTO();
	public List<ProductGetDTO> Products = new List<ProductGetDTO>();
	public List<BrandGetDTO> Brands = new List<BrandGetDTO>();
	public List<ShopSliderGetDTO> ShopSliders = new List<ShopSliderGetDTO>();
	public List<CategoryGetDTO> Categories = new List<CategoryGetDTO>();
	public PaginatedList<Product> PaginatedProducts = new PaginatedList<Product>();
	public List<Comment> Comments = new List<Comment>();

}
