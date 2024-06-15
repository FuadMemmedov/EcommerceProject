using Business.DTOs.FaqDTOs;
using Business.DTOs.ProductColorDTOs;
using Business.DTOs.ProductDTOs;
using Business.Exceptions;
using Business.Service.Abstracts;
using Business.Service.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace TechnoStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductColorController : Controller
    {
        private readonly IProductColorService _productColorService;

        public ProductColorController(IProductColorService productColorService)
        {
            _productColorService = productColorService;
        }

        public IActionResult Index()
        {
            var productColors = _productColorService.GetAllProductColors(x=> x.IsDeleted == false);
            return View(productColors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductColorCreateDTO productColorCreateDTO)
        {
            if (!ModelState.IsValid)
                return View();

                await _productColorService.AddProductColorAsync(productColorCreateDTO);
            
            
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var existProductColor = _productColorService.GetProductColor(x => x.Id == id);

            if (existProductColor == null) return NotFound();

            ProductColorUpdateDTO productUpdateDTO = new ProductColorUpdateDTO
            {
                Id = existProductColor.Id,
                HexCode = existProductColor.HexCode,
                Name = existProductColor.Name
            };




            return View(productUpdateDTO);
        }

        [HttpPost]
        public IActionResult Update(ProductColorUpdateDTO productColorUpdateDTO)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _productColorService.UpdateProductColor(productColorUpdateDTO);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
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
                _productColorService.DeleteProductColor(id);
            }
            catch (EntityNotFoundException ex)
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
            try
            {
                _productColorService.SoftDelete(id);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }
        public IActionResult Return(int id)
        {
            try
            {
                _productColorService.ReturnProductColor(id);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }


        public IActionResult Archive()
        {
            var productColors = _productColorService.GetAllProductColors(x => x.IsDeleted == true);

            return View(productColors);
        }
    }
}
