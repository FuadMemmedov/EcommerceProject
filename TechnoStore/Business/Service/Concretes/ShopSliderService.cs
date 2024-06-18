using AutoMapper;
using Business.DTOs.SliderDTOs;
using Business.Exceptions;
using Business.Extensions;
using Business.Service.Abstracts;
using Core.Models;
using Core.RepositoryAbstracts;
using Data.RepositoryConcretes;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Concretes;

public class ShopSliderService : IShopSliderService
{
	private readonly IShopSliderRepository _shopSliderRepository;
	private readonly IWebHostEnvironment _env;
	private readonly IMapper _mapper;

	public ShopSliderService(IShopSliderRepository shopSliderRepository, IMapper mapper, IWebHostEnvironment env)
	{
		_shopSliderRepository = shopSliderRepository;
		_mapper = mapper;
		_env = env;
	}

	public async Task AddShopSliderAsync(ShopSliderCreateDTO createDTO)
	{
		if (createDTO.ImageFile == null) throw new EntityFileNotFoundException("Image file is required");


		ShopSlider slider = _mapper.Map<ShopSlider>(createDTO);

		slider.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads/shopsliders", createDTO.ImageFile, "shopslider");

		await _shopSliderRepository.AddEntityAsync(slider);
		await _shopSliderRepository.CommitAsync();
	}

	public void DeleteShopSlider(int id)
	{

		var existSlider = _shopSliderRepository.GetEntity(x => x.Id == id);
		if (existSlider == null) throw new EntityNotFoundException("ShopSlider not found");

		Helper.DeleteFile(_env.WebRootPath, @"uploads\shopsliders", existSlider.ImageUrl);



		_shopSliderRepository.DeleteEntity(existSlider);
		_shopSliderRepository.Commit();

	}

	public List<ShopSliderGetDTO> GetAllShopSliders(Func<ShopSlider, bool>? func = null)
	{
		var shopSliders = _shopSliderRepository.GetAllEntities(func);
		List<ShopSliderGetDTO> slidersDto = _mapper.Map<List<ShopSliderGetDTO>>(shopSliders);


		return slidersDto;
	}

	public ShopSliderGetDTO GetShopSlider(Func<ShopSlider, bool>? func = null)
	{
		var shopSlider = _shopSliderRepository.GetEntity(func);
		ShopSliderGetDTO sliderDto = _mapper.Map<ShopSliderGetDTO>(shopSlider);

		return sliderDto;

	}

    public void ReturnShopSlider(int id)
    {
        var existShopSlider = _shopSliderRepository.GetEntity(x => x.Id == id);
        if (existShopSlider == null) throw new EntityNotFoundException("ShopSlider not found!");

        _shopSliderRepository.ReturnEntity(existShopSlider);

        _shopSliderRepository.Commit();
    }

    public void SoftDelete(int id)
	{
		var existShopSlider = _shopSliderRepository.GetEntity(x => x.Id == id);
		if (existShopSlider == null) throw new EntityNotFoundException("ShopSlider not found!");

		existShopSlider.DeletedDate = DateTime.UtcNow.AddHours(4);

		_shopSliderRepository.SoftDelete(existShopSlider);

        _shopSliderRepository.Commit();
    }

	public void UpdateShopSlider(ShopSliderUpdateDTO updateDTO)
	{
		var oldSlider = _shopSliderRepository.GetEntity(x => x.Id == updateDTO.Id);
		if (oldSlider == null) throw new EntityNotFoundException("ShopSlider not found");

		if (updateDTO.ImageFile != null)
		{
			ShopSlider slider = _mapper.Map<ShopSlider>(updateDTO);

			slider.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads/shopsliders", updateDTO.ImageFile, "shopslider");
			Helper.DeleteFile(_env.WebRootPath, @"uploads\shopsliders", oldSlider.ImageUrl);

			oldSlider.ImageUrl = slider.ImageUrl;

		}

		oldSlider.Title = updateDTO.Title;
	
		oldSlider.UpdatedDate = DateTime.UtcNow.AddHours(4);


		_shopSliderRepository.Commit();
	}
}
