using AutoMapper;
using Business.DTOs.FaqDTOs;
using Business.DTOs.ProductDTOs;
using Business.Extensions;
using Business.Service.Abstracts;
using Core.Models;
using Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Xml.Linq;
using TechnoStore.ViewModels;

namespace TechnoStore.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopSliderService _shopSliderService;
        private readonly IProductService _productService;
        private readonly IProductColorService _productColorService;
        private readonly IBrandService _brandService;
		private readonly IMapper _mapper;
		private readonly ICategoryService _categoryService;
		

        public ShopController(IShopSliderService shopSliderService, IProductService productService, IProductColorService productColorService, IBrandService brandService, IMapper mapper, ICategoryService categoryService)
        {
            _shopSliderService = shopSliderService;
            _productService = productService;
            _productColorService = productColorService;
            _brandService = brandService;
            _mapper = mapper;
            _categoryService = categoryService;
           
        }

        public IActionResult Index(int? order,int page = 1)
        {
			var products = _productService.GetAllProducts(x => x.IsDeleted == false).AsQueryable();
			List<Product> productGetDTOs = _mapper.Map<List<Product>>(products);
			var paginatedDatas = PaginatedList<Product>.Create(productGetDTOs, 1, page);
		
			ShopVm shopVm  = new ShopVm
			{
				Colors = _productColorService.GetAllProductColors(x => x.IsDeleted == false),
				Brands = _brandService.GetAllBrands(x => x.IsDeleted == false),
				ShopSliders = _shopSliderService.GetAllShopSliders(x => x.IsDeleted == false),
				Categories = _categoryService.GetAllCategories(x => x.IsDeleted == false),
				Products = _productService.GetAllProducts(x => x.IsDeleted == false),
				PaginatedProducts = paginatedDatas,
				

		    };

			if(order != null)
			{
				switch (order)
				{
					case 1:
						products = products.OrderBy(x => x.Price);
						break;
					case 2:
						products = products.OrderBy(x => x.Name);
						break;
					case 3:
						products = products.OrderByDescending(x => x.Price);
						break;
					case 4:
						products = products.OrderByDescending(x => x.Name);
						break;
					default:
						break;
				}
			}




			return View(shopVm);
        }


		public IActionResult Detail(int id)
		{
			ShopVm shopVm = new ShopVm
			{

				Product = _productService.GetProduct(x => x.Id == id && x.IsDeleted == false),
				Colors = _productColorService.GetAllProductColors(x => x.IsDeleted == false),

			};

			return View(shopVm);
		}



		public IActionResult Filter(string? search,decimal? minPrice, decimal? maxPrice, List<int> selectedBrands, List<int> selectedColors)
        {
			var products = _productService.GetAllProducts(x => x.IsDeleted == false).AsQueryable();

			if (search != null)
			{
				products = products.Where(x => x.Name.ToLower().Contains(search.Trim().ToLower()) || x.Category.Name.ToLower().Contains(search.Trim().ToLower()) || x.Brand.Name.ToLower().Contains(search.Trim().ToLower()));
			}

			if (selectedBrands != null)
			{
				foreach(var item in selectedBrands)
				{
					products = products.Where(x => x.Brand.Id == item);
				}
				
			}

			if (selectedColors != null)
			{
				foreach (var item in selectedColors)
				{
					products = products.Where(x => x.ProductColor.Id == item);
				}
			}

			if(minPrice != null)
			{
				products = products = products.Where(x => x.Price >= minPrice); 
			}


			if (maxPrice != null)
			{
				products = products = products.Where(x => x.Price <= maxPrice); ;
			}



			List<ProductGetDTO> productGetDTOs = _mapper.Map<List<ProductGetDTO>>(products);

			ShopVm shopVm = new ShopVm
			{

				Brands = _brandService.GetAllBrands(x=> x.IsDeleted == false),
				Colors = _productColorService.GetAllProductColors(x => x.IsDeleted == false),
				Products = productGetDTOs


			};
			return View(shopVm);
		}


		//     [HttpPost]
		//     public IActionResult Detail(string userName, string content)
		//     {
		//         if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(content))
		//         {
		//             var comment = new Comment
		//             {
		//                 FullName = userName,
		//                 Content = content,
		//                 CreatedDate = DateTime.Now
		//             };

		//             _appDbContext.Comments.Add(comment);
		//	_appDbContext.SaveChanges();
		//         }

		//return RedirectToAction("index");
		//     }


		public IActionResult AddToBasket(int productId)
		{
			ProductGetDTO product = _productService.GetProduct(x => x.Id == productId);
			if (product == null) return NotFound();

			List<BasketItemVm> basketItemVms = new List<BasketItemVm>();
			BasketItemVm basketItemVm = null;

			string basketItemsStr = HttpContext.Request.Cookies["BasketItems"];

			// Ensure the cookie is a JSON array
			if (string.IsNullOrEmpty(basketItemsStr))
			{
				basketItemVms = new List<BasketItemVm>();
			}
			else
			{
				try
				{
					basketItemVms = JsonConvert.DeserializeObject<List<BasketItemVm>>(basketItemsStr);
				}
				catch (JsonSerializationException ex)
				{
					// Log the exception and return an error response
					Console.WriteLine("Error deserializing cookie: " + ex.Message);
					return BadRequest("Invalid cookie format");
				}
			}

			basketItemVm = basketItemVms.FirstOrDefault(x => x.ProductId == productId);

			if (basketItemVm != null)
			{
				basketItemVm.Count++;
			}
			else
			{
				basketItemVm = new BasketItemVm()
				{
					ProductId = productId,
					Count = 1
				};

				basketItemVms.Add(basketItemVm);
			}

			basketItemsStr = JsonConvert.SerializeObject(basketItemVms);

			HttpContext.Response.Cookies.Append("BasketItems", basketItemsStr);

			return Ok();
		}


		//public IActionResult GetBasketItems()
		//{
		//	List<BasketItemVm> basketItemVms = new List<BasketItemVm>();

		//	string basketItemsStr = HttpContext.Request.Cookies["BasketItems"];

		//	if(basketItemsStr != null)
		//	{
		//		basketItemVms = JsonConvert.DeserializeObject<List<BasketItemVm>>(basketItemsStr);
		//	}


		//	return Json(basketItemVms);
		//}

		public IActionResult CheckOut()
		{
			List<CheckOutVm> checkOutVms = new List<CheckOutVm>();
			List<BasketItemVm> basketItemVms = new List<BasketItemVm>();

			CheckOutVm checkOutVm = null;

			string basketItemsStr = HttpContext.Request.Cookies["BasketItems"];

			if(basketItemsStr != null)
			{
				basketItemVms = JsonConvert.DeserializeObject<List<BasketItemVm>>(basketItemsStr);

				foreach(var item in basketItemVms)
				{
					checkOutVm = new CheckOutVm
					{
						Product = _productService.GetProduct(x => x.Id == item.ProductId),
						Count = item.Count
					};

					checkOutVms.Add(checkOutVm);
				}

				 //basketItemVms.Select(x=> new CheckOutVm() {Product = x.ProductId})

			}



			return View(checkOutVms);
		}
		 
    }
}
