using Business.DTOs.ProductDTOs;
using Business.DTOs.SliderDTOs;
using Business.Exceptions;
using Business.Service.Abstracts;
using Business.Service.Concretes;
using Data.DAL;
using Microsoft.AspNetCore.Mvc;

namespace TechnoStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
      
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();

            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _categoryService.GetAllCategories();
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDTO productCreateDTO)
        {
            
            ViewBag.Categories = _categoryService.GetAllCategories();

            if (!ModelState.IsValid)
            {
                return View();
            }
            await _productService.AddProduct(productCreateDTO);
            return RedirectToAction("Index");
        }
		public IActionResult Update(int id)
		{
			var existProduct = _productService.GetProduct(x => x.Id == id);

			if (existProduct == null) return NotFound();
			ViewBag.Categories = _categoryService.GetAllCategories();

			ProductUpdateDTO productUpdateDTO = new ProductUpdateDTO
			{
				Name = existProduct.Name,
				Price = existProduct.Price,
				Description = existProduct.Description,
				ShortDescription = existProduct.ShortDescription,
				DiscountPercent =  existProduct.DiscountPercent,
				CostPrice = existProduct.CostPrice,
				CategoryId = existProduct.Category.Id

			};

		


			return View(productUpdateDTO);
		}

		[HttpPost]
		public IActionResult Update(ProductUpdateDTO productUpdateDTO)
		{
			ViewBag.Categories = _categoryService.GetAllCategories();
			if (!ModelState.IsValid)
				return View();

			try
			{
				_productService.UpdateProduct(productUpdateDTO);
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
	}
}
