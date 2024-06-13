using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models;

public class Product:BaseEntity
{
	public string Name { get; set; }
	public string ShortDescription { get; set; }
	public string Description { get; set; }
	public decimal Price { get; set; }
	public decimal DiscountPercent { get; set; }
	public decimal CostPrice { get; set; }
	public int CategoryId { get; set; }
	public List<ProductImage>? ProductImages { get; set; }
	public Category Category { get; set; }


}
