using Business.DTOs.BrandDTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Abstracts;

public interface IBrandService
{
    Task AddBrandAsync(BrandCreateDTO brandCreateDTO);
    void DeleteBrand(int id);
    void SoftDelete(int id);
    void ReturnBrand(int id);
    void UpdateBrand(BrandUpdateDTO updateDTO);
    BrandGetDTO GetBrand(Func<Brand, bool>? func = null, params string[]? includes);
    List<BrandGetDTO> GetAllBrands(Func<Brand, bool>? func = null, params string[]? includes);
}
