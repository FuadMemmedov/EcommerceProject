using AutoMapper;
using Business.DTOs.FaqDTOs;
using Business.DTOs.ProductDTOs;
using Business.Extensions;
using Business.Service.Abstracts;
using Core.Models;
using Data.DAL;
using Microsoft.AspNetCore.Identity;
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
		private readonly UserManager<AppUser> _userManager;
		private readonly IBasketItemService _basketItemService;
		private readonly AppDbContext _appDbContext;

        public ShopController(IShopSliderService shopSliderService, IProductService productService, IProductColorService productColorService, IBrandService brandService, IMapper mapper, ICategoryService categoryService, UserManager<AppUser> userManager, IBasketItemService basketItemService, AppDbContext appDbContext)
        {
            _shopSliderService = shopSliderService;
            _productService = productService;
            _productColorService = productColorService;
            _brandService = brandService;
            _mapper = mapper;
            _categoryService = categoryService;
            _userManager = userManager;
            _basketItemService = basketItemService;
            _appDbContext = appDbContext;
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

		public async Task<IActionResult> AddToBasket(int productId)
		{
          
   //         List<BasketItemVm> basketItems = new List<BasketItemVm>();

			//BasketItemVm basketItem = new BasketItemVm()
			//{
			//	ProductId = productId,
			//	Count = 1
			//};

			ProductGetDTO product = _productService.GetProduct(x => x.Id == productId);

			if (product == null) return NotFound();

			List<BasketItemVm> BasketItemViewModels = new List<BasketItemVm>();
			BasketItemVm BasketItemViewModel = null;
			BasketItem userBasketItem = null;
			AppUser user = null;

			if (HttpContext.User.Identity.IsAuthenticated)
			{
				user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
			}

			if (user == null)
			{
				string basketItemsStr = HttpContext.Request.Cookies["BasketItems"];

				if (string.IsNullOrEmpty(basketItemsStr))
				{
					BasketItemViewModels = new List<BasketItemVm>();
				}
				else
				{
					try
					{
						BasketItemViewModels = JsonConvert.DeserializeObject<List<BasketItemVm>>(basketItemsStr);
					}
					catch (JsonSerializationException ex)
					{
						Console.WriteLine("Error deserializing cookie: " + ex.Message);
						return BadRequest("Invalid cookie format");
					}
				}

				BasketItemViewModel = BasketItemViewModels.FirstOrDefault(x => x.ProductId == productId);

                if (BasketItemViewModel != null)
                {
                    BasketItemViewModel.Count++;
                }
                else
                {
                    BasketItemViewModel = new BasketItemVm()
                    {
                        ProductId = productId,
                        Count = 1
                    };
                    BasketItemViewModels.Add(BasketItemViewModel);
                }

                    basketItemsStr = JsonConvert.SerializeObject(BasketItemViewModels);

				HttpContext.Response.Cookies.Append("BasketItems", basketItemsStr);
			}
			else
			{
				userBasketItem = _basketItemService.GetBasketItem(x => x.ProductId == productId &&
				x.UserId == user.Id && !x.IsDeleted);
				if (userBasketItem != null)
				{
					userBasketItem.Counter++;
				}
				else
				{
					userBasketItem = new BasketItem
					{
						ProductId = productId,
						Counter = 1,
						UserId = user.Id,
						IsDeleted = false
					};
					await _basketItemService.AddBasketItem(userBasketItem);
				}

			}




			return Ok();

		}


	
	

        public async Task<IActionResult> CheckOut()
        {

            List<CheckOutVm> checkOutVms = new List<CheckOutVm>();
            List<BasketItemVm> basketItemVms = new List<BasketItemVm>();
            List<BasketItem> userBasketItems = new List<BasketItem>();
            CheckOutVm checkOutVm = null;
            AppUser user = null;

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            }

            if (user == null)
            {
                string basketItemsStr = HttpContext.Request.Cookies["BasketItems"];

                if (basketItemsStr != null)
                {
                    basketItemVms = JsonConvert.DeserializeObject<List<BasketItemVm>>(basketItemsStr);

                    foreach (var item in basketItemVms)
                    {
                        checkOutVm = new CheckOutVm
                        {
                            Product = _productService.GetProduct(x => x.Id == item.ProductId),
                            Count = item.Count
                        };

                        checkOutVms.Add(checkOutVm);
                    }
                }
            }
            else
            {
                userBasketItems = _basketItemService.GetAllBasketItems(x => x.UserId ==
                user.Id && !x.IsDeleted).ToList();

                foreach (var item in userBasketItems)
                {
                    checkOutVm = new CheckOutVm
                    {
                        Product = _mapper.Map<ProductGetDTO>(item.Product),
                        Count = item.Counter
                    };
                    checkOutVms.Add(checkOutVm);
                }
            }

            OrderVm orderViewModel = new OrderVm
            {
                CheckOutVms = checkOutVms,
                Name = user?.Name,
                Surname = user?.Surname,
            };

            return View(orderViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CheckOut(OrderVm orderViewModel)
        {
            if (!ModelState.IsValid)
                return View();

            List<CheckOutVm> checkOutVms = new List<CheckOutVm>();
            List<BasketItemVm> basketItemVms = new List<BasketItemVm>();
            List<BasketItem> userBasketItems = new List<BasketItem>();
            CheckOutVm checkOutVm = null;
            OrderItem orderItem = null;
            AppUser user = null;

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            }

            Order order = new Order
            {
                Name = orderViewModel.Name,
                Surname = orderViewModel.Surname,
                Address = orderViewModel.Address,
                Country = orderViewModel.Country,
                Email = orderViewModel.Email,
                Phone = orderViewModel.Phone,
                ZipCode = orderViewModel.ZipCode,
                Note = orderViewModel.Note,
                OrderItems = new List<OrderItem>(),
                AppUserId = user?.Id,
                CreatedDate = DateTime.UtcNow.AddHours(4)
            };

            order.OrderItems = new List<OrderItem>();

            if (user == null)
            {
                string basketItemsStr = HttpContext.Request.Cookies["BasketItems"];

                if (basketItemsStr != null)
                {
                    basketItemVms = JsonConvert.DeserializeObject<List<BasketItemVm>>(basketItemsStr);

                    foreach (var item in basketItemVms)
                    {
                        //RoomGetDTO roomGetDTO = _roomService.GetRoom(x => x.Id == item.RoomId);
                        //Room room = _mapper.Map<Room>(roomGetDTO);
                        Product product = _appDbContext.Products.FirstOrDefault(x => x.Id == item.ProductId);


                        orderItem = new OrderItem
                        {
                            Product = product,
                            ProductName = product.Name,
                            DiscountPercent = product.DiscountPercent,
                            Price = product.Price - product.Price * product.DiscountPercent / 100,  
                            Count = 2, 
                            Order = order
                        };

                        order.TotalPrice += orderItem.Price * orderItem.Count;

                        order.OrderItems.Add(orderItem);

                    }
                }
            }
            else
            {
                userBasketItems = _basketItemService.GetAllBasketItems(x => x.UserId ==
                    user.Id).ToList();

                foreach (var item in userBasketItems)
                {
                   

                    Product product = _appDbContext.Products.FirstOrDefault(x => x.Id == item.ProductId);


                    orderItem = new OrderItem
                    {
                        Product = product,
                        ProductName = product.Name,
                        DiscountPercent = product.DiscountPercent,
                        Price = product.Price - product.Price * product.DiscountPercent / 100,  
                        Count = 1, 
                        Order = order
                    };


                    order.TotalPrice += orderItem.Price * orderItem.Count;
                    order.OrderItems.Add(orderItem);

                    item.IsDeleted = true;
                }
            }

            //TODO Stripe



            await _appDbContext.Orders.AddAsync(order);
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

    }
}
