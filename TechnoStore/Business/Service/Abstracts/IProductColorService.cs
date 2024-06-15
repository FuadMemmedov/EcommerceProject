using Business.DTOs.ProductColorDTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Abstracts;

public interface IProductColorService
{
    Task AddProductColorAsync(ProductColorCreateDTO productColorCreateDTO);
    void DeleteProductColor(int id);
    void SoftDelete(int id);
    void ReturnProductColor(int id);
    void UpdateProductColor(ProductColorUpdateDTO updateDTO);
    ProductColorGetDTO GetProductColor(Func<ProductColor, bool>? func = null, params string[]? includes);
    List<ProductColorGetDTO> GetAllProductColors(Func<ProductColor, bool>? func = null, params string[]? includes);
}
