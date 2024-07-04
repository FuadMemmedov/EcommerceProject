using AutoMapper;
using Business.Service.Abstracts;
using Business.Service.Concretes;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.ViewModels;

namespace TechnoStore.ViewService;

public class LayoutService
{
    private readonly IBasketItemService _basketItemService;
    private readonly IProductService _productService;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly UserManager<AppUser> _userManager;
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;
    private readonly SettingService _settingService;

	public LayoutService(IBasketItemService basketItemService, IProductService productService, UserManager<AppUser> userManager, IHttpContextAccessor contextAccessor, ICategoryService categoryService, IMapper mapper, SettingService settingService)
	{
		_basketItemService = basketItemService;
		_productService = productService;
		_userManager = userManager;
		_contextAccessor = contextAccessor;
		_categoryService = categoryService;
		_mapper = mapper;
		_settingService = settingService;
	}

	public async Task<List<Setting>> GetSetting()
	{
        var settings = _settingService.GetAllSettings();

		List<Setting> settingGetDtos = _mapper.Map<List<Setting>>(settings);
		
		return settingGetDtos;
	}

	public async Task<AppUser> GetUserData()
	{
		if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
		{
			return await _userManager.FindByNameAsync(_contextAccessor.HttpContext.User.Identity.Name);
		}
		return null;
	}

	public List<Category> GetAllCategories()
    {
        var categories = _categoryService.GetAllCategories(x => x.IsDeleted == false && x.ParentCategoryId == null);
        List<Category> categoryGetDtos = _mapper.Map<List<Category>>(categories);

        return categoryGetDtos;
    }

    public async Task<List<BasketItemVm>> Basket()
    {
        List<BasketItemVm> products = new();
        AppUser user = null;

        if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
        {
            user = await _userManager.FindByNameAsync(_contextAccessor.HttpContext.User.Identity.Name);
        }

        if (user == null)
        {
            var baskets = _contextAccessor.HttpContext.Request.Cookies["BasketItems"];
            if (baskets != null)
            {
                products = JsonConvert.DeserializeObject<List<BasketItemVm>>(baskets);
                foreach (var item in products)
                {
                    var existProduct = _productService.GetProduct(x => x.Id == item.ProductId);
                    if (existProduct != null)
                    {
                        item.Name = existProduct.Name;
                        item.Price = existProduct.Price;
                        item.ImageUrl = existProduct.ProductImages.FirstOrDefault(x => x.IsPoster)?.ImageUrl;
                        item.DiscountPercent = existProduct.DiscountPercent;
                    }
                }
            }
        }
        else
        {

            var basketItems = _basketItemService.GetAllBasketItems(x => x.UserId ==
              user.Id && !x.IsDeleted);

            if (basketItems != null)
            {
                foreach (var basketItem in basketItems)
                {
                    var existProduct = _productService.GetProduct(x => x.Id == basketItem.ProductId);
                    if (existProduct != null)
                    {
                        products.Add(new BasketItemVm
                        {
                            ProductId = basketItem.ProductId,
                            Count = basketItem.Counter,
                            Name = existProduct.Name,
                            Price = existProduct.Price,
                            ImageUrl = existProduct.ProductImages.FirstOrDefault(x => x.IsPoster)?.ImageUrl,
                            DiscountPercent = existProduct.DiscountPercent
                        });
                    }
                }
            }
        }

        return products;
    }

 

}

