using AutoMapper;
using Business.DTOs.BlogDTOs;
using Business.DTOs.BrandDTOs;
using Business.DTOs.CategoryDTOs;
using Business.DTOs.FaqDTOs;
using Business.DTOs.ProductColorDTOs;
using Business.DTOs.ProductDTOs;
using Business.DTOs.SettingDTOs;
using Business.DTOs.SliderDTOs;
using Business.DTOs.TagDTOs;
using Business.DTOs.TeamDTOs;
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


        CreateMap<ProductColorCreateDTO, ProductColor>().ReverseMap();
        CreateMap<ProductColor, ProductColorGetDTO>().ReverseMap();
        CreateMap<ProductColorUpdateDTO, ProductColor>().ReverseMap();

        CreateMap<BrandCreateDTO, Brand>().ReverseMap();
        CreateMap<Brand, BrandGetDTO>().ReverseMap();
        CreateMap<BrandUpdateDTO, Brand>().ReverseMap();

		CreateMap<SettingCreateDTO, Setting>().ReverseMap();
		CreateMap<Setting, SettingGetDTO>().ReverseMap();
		CreateMap<SettingUpdateDTO, Setting>().ReverseMap();

		CreateMap<TeamCreateDTO, Team>().ReverseMap();
		CreateMap<Team, TeamGetDTO>().ReverseMap();
		CreateMap<TeamUpdateDTO, Team>().ReverseMap();

		CreateMap<BlogCreateDTO, Blog>().ReverseMap();
		CreateMap<Blog, BlogGetDTO>().ReverseMap();
		CreateMap<BlogUpdateDTO, Blog>().ReverseMap();

        CreateMap<TagCreateDTO, Tag>().ReverseMap();
        CreateMap<Tag, TagGetDTO>().ReverseMap();
        CreateMap<TagUpdateDTO, Tag>().ReverseMap();
    }
}
