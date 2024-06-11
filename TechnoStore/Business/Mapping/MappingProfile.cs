using AutoMapper;
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
    }
}
