using Business.DTOs.ProductColorDTOs;
using Business.DTOs.ProductDTOs;
using Business.DTOs.SliderDTOs;

namespace TechnoStore.ViewModels;

public class HomeVm
{
    public List<SliderGetDTO> Sliders = new List<SliderGetDTO>();
    public List<ProductGetDTO> Products = new List<ProductGetDTO>();
    public List<ProductColorGetDTO> Colors = new List<ProductColorGetDTO>();
    public ProductGetDTO Product = new ProductGetDTO();
}
