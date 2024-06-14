using Business.DTOs.SliderDTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Abstracts;

public interface ISliderService
{
	Task AddSliderAsync(SliderCreateDTO createDTO);
	void DeleteSlider(int id);
	void SoftDelete(int id);
	void UpdateSlider(SliderUpdateDTO updateDTO);
	SliderGetDTO GetSlider(Func<Slider, bool>? func = null);
	List<SliderGetDTO> GetAllSliders(Func<Slider, bool>? func = null);
}
