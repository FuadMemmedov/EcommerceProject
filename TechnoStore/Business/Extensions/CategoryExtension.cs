using Business.DTOs.CategoryDTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extensions;

public static class CategoryExtension
{
	public static string GetCategoriesRaw(this List<Category> categories)
	{
		if (categories == null || !categories.Any())
			return "";

		StringBuilder sb = new StringBuilder();

		sb.Append("<ul class='cat-list style1 widget-content'>");

		foreach (var item in categories)
		{
			FillCategoriesRaw(item);
		}

		sb.Append("</ul>");
		return sb.ToString();

		void FillCategoriesRaw(Category category)
		{


			
				
				sb.Append($"<li><span>{category.Name}</span>");

				




				


				if (category.SubCategories != null && category.SubCategories.Any())
				{
					sb.Append("<ul class='cat-child'>");

				     foreach(var subcategory in category.SubCategories)
					{
						sb.Append($"<li><a href='/Shop/Index?categoryId={subcategory.Id}'>{subcategory.Name}</a></li>");
					}
					sb.Append("</ul>");
				}

				sb.Append("</li>");

			
		}

       
    }
	public static string GetAllCategoriesRaw(this List<Category> categories)
	{
		if (categories == null || !categories.Any())
			return "";

		StringBuilder sb = new StringBuilder();

		sb.Append("<ul class='menu'>");

		foreach (var category in categories)
		{
			FillCategoriesRaw(category, sb);
		}

		sb.Append("</ul>");
		return sb.ToString();

		void FillCategoriesRaw(Category category, StringBuilder sb)
		{
			sb.Append("<li>");

			if (category.SubCategories != null && category.SubCategories.Any())
			{
				sb.Append("<a href='#' title='' class='dropdown'>");




                var imageUrl = $"/uploads/categories/{category.IconUrl}";
                sb.Append($"<span class='menu-img'><img src='{imageUrl}' alt='{category.Name}'></span>");



                sb.Append($"<span class='menu-title'>{category.Name}</span>");
				sb.Append("</a>");

				sb.Append("<div class='drop-menu'>");

			

				foreach (var subCategory in category.SubCategories)
				{
					sb.Append("<div class='one-third'>");
					sb.Append($"<div class='cat-title'>{subCategory.Name}</div>");
					sb.Append("<ul>");

					foreach (var subItem in subCategory.SubCategories)
					{
						sb.Append($"<li><a href='/Shop/Index?categoryId={subItem.Id}' title=''>{subItem.Name}</a></li>");
					}

					sb.Append("</ul>");
					sb.Append("<div class='show'><a href='/Shop/Index' title=''>Shop All</a></div>");
					sb.Append("</div>");
				}

				sb.Append("</div>");
			}
			else
			{
				sb.Append($"<a href='/Shop/Index?categoryId={category.Id}' title=''>{category.Name}</a>");
			}

			sb.Append("</li>");
		}
	}



}


