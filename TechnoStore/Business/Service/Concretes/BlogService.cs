using AutoMapper;
using Business.DTOs.BlogDTOs;
using Business.DTOs.TeamDTOs;
using Business.Exceptions;
using Business.Extensions;
using Business.Service.Abstracts;
using Core.Models;
using Core.RepositoryAbstracts;
using Data.DAL;
using Data.RepositoryConcretes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Concretes;

public class BlogService : IBlogService
{
	private readonly IBlogRepository _blogRepository;
	private readonly IWebHostEnvironment _env;
	private readonly IMapper _mapper;
	private readonly IBlogTagRepository _blogTagRepository;
	private readonly ITagRepository _tagRepository;
	private readonly IBlogCategoryRepository _blogCategory;

	public BlogService(
		IBlogRepository blogRepository,
		IWebHostEnvironment env,
		IMapper mapper,
		IBlogTagRepository blogTagRepository,
		ITagRepository tagRepository,
		IBlogCategoryRepository blogCategory)
	{
		_blogRepository = blogRepository;
		_env = env;
		_mapper = mapper;
		_blogTagRepository = blogTagRepository;
		_tagRepository = tagRepository;
		_blogCategory = blogCategory;
	}

	public async Task AddBlogAsync(BlogCreateDTO blogCreateDTO)
	{
		Blog blog = _mapper.Map<Blog>(blogCreateDTO);
		var existBlogCategory = _blogCategory.GetEntity(x => x.Id == blogCreateDTO.BlogCategoryId);
		if (existBlogCategory == null) throw new EntityNotFoundException("BlogCategory not found!");

		blog.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads/blogs", blogCreateDTO.ImageFile, "blog");

		await _blogRepository.AddEntityAsync(blog);
		await _blogRepository.CommitAsync();

		if (blogCreateDTO.TagIds != null)
		{
			foreach (var tagId in blogCreateDTO.TagIds)
			{
				if (!_tagRepository.GetAllEntities().Any(x => x.Id == tagId))
					throw new EntityNotFoundException("Tag not found!");

				BlogTag blogTag = new BlogTag
				{
					TagId = tagId,
					BlogId = blog.Id,
					CreatedDate = DateTime.UtcNow.AddHours(4),
				};
				await _blogTagRepository.AddEntityAsync(blogTag);
			}
		}

		await _blogRepository.CommitAsync();
	}

	public void DeleteBlog(int id)
	{
		var existBlog = _blogRepository.GetEntity(x => x.Id == id);
		if (existBlog == null) throw new EntityNotFoundException("Blog not found");

		Helper.DeleteFile(_env.WebRootPath, @"uploads\blogs", existBlog.ImageUrl);

		_blogRepository.DeleteEntity(existBlog);
		_blogRepository.Commit();
	}

	public List<BlogGetDTO> GetAllBlogs(Func<Blog, bool>? func = null)
	{
		var blogs = _blogRepository.GetAllEntities(func,"BlogCategory");
		List<BlogGetDTO> blogGetDTOs = _mapper.Map<List<BlogGetDTO>>(blogs);

		return blogGetDTOs;
	}

	public BlogGetDTO GetBlog(Func<Blog, bool>? func = null)
	{
		var blog = _blogRepository.GetEntity(func,"BlogCategory");
		BlogGetDTO blogGetDTOs = _mapper.Map<BlogGetDTO>(blog);

		return blogGetDTOs;
	}

	public void ReturnBlog(int id)
	{
		var existBlog = _blogRepository.GetEntity(x => x.Id == id);
		if (existBlog == null) throw new EntityNotFoundException("Blog not found!");

		_blogRepository.ReturnEntity(existBlog);
		_blogRepository.Commit();
	}

	public void SoftDelete(int id)
	{
		var existBlog = _blogRepository.GetEntity(x => x.Id == id);
		if (existBlog == null) throw new EntityNotFoundException("Blog not found!");

		existBlog.DeletedDate = DateTime.UtcNow.AddHours(4);
		_blogRepository.SoftDelete(existBlog);
		_blogRepository.Commit();
	}

	public async void UpdateBlog(BlogUpdateDTO updateDTO)
	{
		var oldBlog = _blogRepository.GetEntity(x => x.Id == updateDTO.Id);
		if (oldBlog == null) throw new EntityNotFoundException("Blog not found");

		if (updateDTO.ImageFile != null)
		{

			Blog blog = _mapper.Map<Blog>(oldBlog);
            blog.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads/blogs", updateDTO.ImageFile, "blog");
			if(oldBlog.ImageUrl != "")
			{
                Helper.DeleteFile(_env.WebRootPath, @"uploads\blogs", oldBlog.ImageUrl);
            }

			oldBlog.ImageUrl = blog.ImageUrl;
		}

		oldBlog.Title = updateDTO.Title;
		oldBlog.Description = updateDTO.Description;
		oldBlog.BlogCategoryId = updateDTO.BlogCategoryId;
		oldBlog.UpdatedDate = DateTime.UtcNow.AddHours(4);

		_blogRepository.Commit();

		if (updateDTO.TagIds != null)
		{
			var existingTags = _blogTagRepository.GetAllEntities(bt => bt.BlogId == oldBlog.Id);
			foreach (var blogTag in existingTags)
			{
				_blogTagRepository.DeleteEntity(blogTag);
			}
			await _blogTagRepository.CommitAsync();

			foreach (var tagId in updateDTO.TagIds)
			{
				if (!_tagRepository.GetAllEntities().Any(x => x.Id == tagId))
					throw new EntityNotFoundException("Tag not found!");

				BlogTag blogTag = new BlogTag
				{
					TagId = tagId,
					BlogId = oldBlog.Id,
					CreatedDate = DateTime.UtcNow.AddHours(4),
				};
				await _blogTagRepository.AddEntityAsync(blogTag);
			}
		}

		await _blogRepository.CommitAsync();
	}
}


