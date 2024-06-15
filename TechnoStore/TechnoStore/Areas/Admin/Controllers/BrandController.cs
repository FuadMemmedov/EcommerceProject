using Business.DTOs.BrandDTOs;
using Business.DTOs.ProductColorDTOs;
using Business.Exceptions;
using Business.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace TechnoStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public IActionResult Index()
        {
            var brands = _brandService.GetAllBrands(x => x.IsDeleted == false);
            return View(brands);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BrandCreateDTO brandCreateDTO)
        {
            if (!ModelState.IsValid)
                return View();

            await _brandService.AddBrandAsync(brandCreateDTO);


            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var existBrand = _brandService.GetBrand(x => x.Id == id);

            if (existBrand == null) return NotFound();

            BrandUpdateDTO brandUpdateDTO = new BrandUpdateDTO
            {
                Id = existBrand.Id,
                Name = existBrand.Name
            };




            return View(brandUpdateDTO);
        }

        [HttpPost]
        public IActionResult Update(BrandUpdateDTO brandUpdateDTO)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _brandService.UpdateBrand(brandUpdateDTO);
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
                _brandService.DeleteBrand(id);
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
                _brandService.SoftDelete(id);
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
                _brandService.ReturnBrand(id);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }


        public IActionResult Archive()
        {
            var brands = _brandService.GetAllBrands(x => x.IsDeleted == true);

            return View(brands);
        }
    
    }
}
