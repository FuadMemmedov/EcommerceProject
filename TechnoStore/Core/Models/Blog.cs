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

    public List<BlogTag> BlogTags = new List<BlogTag>();
	public int BlogCategoryId { get; set; }
	public BlogCategory BlogCategory { get; set; }
}
