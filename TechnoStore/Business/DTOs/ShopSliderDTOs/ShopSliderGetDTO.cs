using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.SliderDTOs;

public class ShopSliderGetDTO
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string ImageUrl { get; set; }
}
