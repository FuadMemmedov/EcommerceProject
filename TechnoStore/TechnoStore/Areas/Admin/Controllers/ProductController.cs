﻿using AutoMapper;
using Business.DTOs.ProductDTOs;
using Business.DTOs.SliderDTOs;
using Business.Exceptions;
using Business.Extensions;
using Business.Service.Abstracts;
using Business.Service.Concretes;
using Core.Models;
using Data.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TechnoStore.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "SuperAdmin")]
	public class ProductController : Controller
    {

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
		private readonly IProductColorService _productColorService;
		private readonly IBrandService _brandService;
		private readonly IMapper _mapper;

        public ProductController(IProductService productService, ICategoryService categoryService, IProductColorService productColorService, IBrandService brandService, IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _productColorService = productColorService;
            _brandService = brandService;
            _mapper = mapper;
        }

        public IActionResult Index(int page = 1)
        {
			
 
            var datas = _productService.GetAllProducts(x => x.IsDeleted == false);

            List<Product> productGetDTOs = _mapper.Map<List<Product>>(datas);

            var paginatedDatas = PaginatedList<Product>.Create(productGetDTOs, 2, page);

            return View(paginatedDatas);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _categoryService.GetAllCategories(x => x.IsDeleted == false);
			ViewBag.ProductColor = _productColorService.GetAllProductColors(x=> x.IsDeleted == false);
            ViewBag.Brand = _brandService.GetAllBrands(x => x.IsDeleted == false);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDTO productCreateDTO)
        {
            
            ViewBag.Categories = _categoryService.GetAllCategories();
            ViewBag.ProductColor = _productColorService.GetAllProductColors(x => x.IsDeleted == false);
            ViewBag.Brand = _brandService.GetAllBrands(x => x.IsDeleted == false);

            if (!ModelState.IsValid)
            {
                return View();
            }
			try
			{
                await _productService.AddProduct(productCreateDTO);
            }
			catch (FileContentTypeException ex)
			{
                ModelState.AddModelError("ImageFiles", ex.Message);
                return View();

            }
            catch (FileSizeException ex)
            {
                ModelState.AddModelError("ImageFiles", ex.Message);
                return View();

            }
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
            return RedirectToAction("Index");
        }
		public IActionResult Update(int id)
		{
			var existProduct = _productService.GetProduct(x => x.Id == id);

			if (existProduct == null) return NotFound();
			ViewBag.Categories = _categoryService.GetAllCategories();
            ViewBag.ProductColor = _productColorService.GetAllProductColors(x => x.IsDeleted == false);
            ViewBag.Brand = _brandService.GetAllBrands(x => x.IsDeleted == false);

			ProductUpdateDTO productUpdateDTO = new ProductUpdateDTO
			{
				Name = existProduct.Name,
				Price = existProduct.Price,
				Description = existProduct.Description,
				ShortDescription = existProduct.ShortDescription,
				DiscountPercent = existProduct.DiscountPercent,
				CostPrice = existProduct.CostPrice,
				CategoryId = existProduct.Category.Id,
				ProductColorId = existProduct.ProductColor.Id,
				BrandId = existProduct.Brand.Id,
				ProductImages = existProduct.ProductImages,
				IsTopSelling = existProduct.IsTopSelling,
				IsNewArrivals = existProduct.IsNewArrivals,
				IsFeatured = existProduct.IsFeatured,
				IsAvaibily = existProduct.IsAvaibily,
				IsHotSale = existProduct.IsHotSale,
				IsBestSellers = existProduct.IsBestSellers
				
				

			};

		


			return View(productUpdateDTO);
		}

		[HttpPost]
		public IActionResult Update(ProductUpdateDTO productUpdateDTO)
		{
			ViewBag.Categories = _categoryService.GetAllCategories();
            ViewBag.ProductColor = _productColorService.GetAllProductColors(x => x.IsDeleted == false);
            ViewBag.Brand = _brandService.GetAllBrands(x => x.IsDeleted == false);
            if (!ModelState.IsValid)
				return View();

			try
			{
				_productService.UpdateProduct(productUpdateDTO);
			}
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (FileContentTypeException ex)
			{
				ModelState.AddModelError("ImageFile", ex.Message);
				return View();
			}
			catch (FileSizeException ex)
			{
				ModelState.AddModelError("ImageFile", ex.Message);
				return View();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			return RedirectToAction("Index");
		}


		public IActionResult Delete(int id)
		{
			try
			{
				_productService.DeleteProduct(id);
			}
			catch (EntityNotFoundException ex)
			{
				return NotFound();
			}
			catch (EntityFileNotFoundException ex)
			{
				return NotFound();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			return Ok();
		}

		public IActionResult SoftDelete(int id)
		{
            var product = _productService.GetProduct(x => x.Id == id);
            if (product == null) return NotFound();
            try
			{
				_productService.SoftDelete(id);
			}
			catch (EntityNotFoundException ex)
			{
				return NotFound();
			}

			return RedirectToAction("Index");
		}
        public IActionResult Return(int id)
        {
            var product = _productService.GetProduct(x => x.Id == id);
            if (product == null) return NotFound();
            try
            {
                _productService.ReturnProduct(id);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }


        public IActionResult Archive()
		{
			var products = _productService.GetAllProducts(x => x.IsDeleted == true);

			return View(products);
		}
	}
}
