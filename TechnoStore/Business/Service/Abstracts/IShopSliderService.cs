using Business.DTOs.SliderDTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Abstracts;

public interface IShopSliderService
{
	Task AddShopSliderAsync(ShopSliderCreateDTO createDTO);
	void DeleteShopSlider(int id);
	void SoftDelete(int id);
	void UpdateShopSlider(ShopSliderUpdateDTO updateDTO);
	ShopSliderGetDTO GetShopSlider(Func<ShopSlider, bool>? func = null);
	List<ShopSliderGetDTO> GetAllShopSliders(Func<ShopSlider, bool>? func = null);
}
