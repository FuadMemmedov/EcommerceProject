using AutoMapper;
using Business.DTOs.CategoryDTOs;
using Business.DTOs.FaqDTOs;
using Business.DTOs.ProductDTOs;
using Business.DTOs.SliderDTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<SliderCreateDTO, Slider>().ReverseMap();
        CreateMap<Slider, SliderGetDTO>().ReverseMap();
        CreateMap<SliderUpdateDTO, Slider>().ReverseMap();

        CreateMap<ShopSliderCreateDTO, ShopSlider>().ReverseMap();
        CreateMap<ShopSlider, ShopSliderGetDTO>().ReverseMap();
        CreateMap<ShopSliderUpdateDTO, ShopSlider>().ReverseMap();

		CreateMap<CategoryCreateDTO, Category>().ReverseMap();
		CreateMap<Category, CategoryGetDTO>().ReverseMap();
		CreateMap<CategoryUpdateDTO, Category>().ReverseMap();

        CreateMap<ProductCreateDTO, Product>().ReverseMap();
        CreateMap<Product, ProductGetDTO>().ReverseMap();
        CreateMap<ProductUpdateDTO, Product>().ReverseMap();

        CreateMap<FaqCreateDTO, Faq>().ReverseMap();
        CreateMap<Faq, FaqGetDTO>().ReverseMap();
        CreateMap<FaqUpdateDTO, Faq>().ReverseMap();

    }
}
