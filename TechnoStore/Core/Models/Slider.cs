using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models;

public class Slider : BaseEntity
{
	public string Title { get; set; }
	public decimal Price { get; set; }
	public decimal DiscountPrice { get; set; }
	public string RedirectUrl { get; set; }
	public string ImageUrl { get; set; }
}
