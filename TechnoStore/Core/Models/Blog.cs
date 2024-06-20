using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models;

public class Blog:BaseEntity
{
	public string Title { get; set; }
	public string Description { get; set; }

	public string ImageUrl { get; set; }

	public List<Comment> Comments { get; set; }
}
