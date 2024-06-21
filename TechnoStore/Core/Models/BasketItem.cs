using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models;

public class BasketItem:BaseEntity
{
	public int ProductId { get; set; }
	public int CounterId { get; set; }

	public Product Product { get; set; }
}
