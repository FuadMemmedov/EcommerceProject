using Business.DTOs.BlogDTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Abstracts;

public interface IBlogService
{
	Task AddBlogAsync(BlogCreateDTO blogCreateDTO);
	void DeleteBlog(int id);
	void SoftDelete(int id);
	void ReturnBlog(int id);
	void UpdateBlog(BlogUpdateDTO updateDTO);
	BlogGetDTO GetBlog(Func<Blog, bool>? func = null);
	List<BlogGetDTO> GetAllBlogs(Func<Blog, bool>? func = null);
}
