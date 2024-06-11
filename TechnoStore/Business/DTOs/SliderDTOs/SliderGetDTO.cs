using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.SliderDTOs;

public class SliderGetDTO
{
	public int Id { get; set; }
	public string Title { get; set; }
	public decimal Price { get; set; }
	public decimal DiscountPrice { get; set; }
	public string RedirectUrl { get; set; }
	public string ImageUrl { get; set; }
}
