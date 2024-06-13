using AutoMapper;
using Business.DTOs.SliderDTOs;
using Business.Exceptions;
using Business.Extensions;
using Business.Service.Abstracts;
using Core.Models;
using Core.RepositoryAbstracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Concretes;

public class SliderService : ISliderService
{
	private readonly ISliderRepository _sliderRepository;
	private readonly IWebHostEnvironment _env;
	private readonly IMapper _mapper;

	public SliderService(ISliderRepository sliderRepository, IWebHostEnvironment env, IMapper mapper)
	{
		_sliderRepository = sliderRepository;
		_env = env;
		_mapper = mapper;
	}

	public async Task AddSliderAsync(SliderCreateDTO createDTO)
	{
		if (createDTO.ImageFile == null) throw new EntityFileNotFoundException("Image file is required");


		Slider slider = _mapper.Map<Slider>(createDTO);

		slider.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads/sliders", createDTO.ImageFile,"slider");

		await _sliderRepository.AddEntityAsync(slider);
		await _sliderRepository.CommitAsync();

	}

	public void DeleteSlider(int id)
	{
		var existSlider = _sliderRepository.GetEntity(x => x.Id == id);
		if (existSlider == null) throw new EntityNotFoundException("Slider not found");

		Helper.DeleteFile(_env.WebRootPath, @"uploads\sliders", existSlider.ImageUrl);
		


        _sliderRepository.DeleteEntity(existSlider);
		_sliderRepository.Commit();

	}

	public List<SliderGetDTO> GetAllSliders(Func<Slider, bool>? func = null)
	{
		var sliders = _sliderRepository.GetAllEntities(func);
		List<SliderGetDTO> slidersDto = _mapper.Map<List<SliderGetDTO>>(sliders);


		return slidersDto;
	}

	public SliderGetDTO GetSlider(Func<Slider, bool>? func = null)
	{
		var slider = _sliderRepository.GetEntity(func);
		SliderGetDTO sliderDto = _mapper.Map<SliderGetDTO>(slider);

		return sliderDto;

	}

	public void UpdateSlider(SliderUpdateDTO updateDTO)
	{
		var oldSlider = _sliderRepository.GetEntity(x => x.Id == updateDTO.Id);
		if (oldSlider == null) throw new EntityNotFoundException("Slider not found");

		if(updateDTO.ImageFile != null)
		{
			
			Slider slider = _mapper.Map<Slider>(updateDTO);

			slider.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads/sliders", updateDTO.ImageFile, "slider");
			Helper.DeleteFile(_env.WebRootPath, @"uploads\sliders", oldSlider.ImageUrl);

			oldSlider.ImageUrl = slider.ImageUrl;

		}

		oldSlider.Title = updateDTO.Title;
		oldSlider.Price = updateDTO.Price;
		oldSlider.DiscountPrice = updateDTO.DiscountPrice;
		oldSlider.RedirectUrl = updateDTO.RedirectUrl;
        oldSlider.UpdatedDate = DateTime.UtcNow.AddHours(4);


        _sliderRepository.Commit();


	}
}
