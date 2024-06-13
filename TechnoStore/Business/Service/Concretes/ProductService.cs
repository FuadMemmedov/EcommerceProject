using AutoMapper;
using Business.DTOs.ProductDTOs;
using Business.DTOs.SliderDTOs;
using Business.Exceptions;
using Business.Extensions;
using Business.Service.Abstracts;
using Core.Models;
using Core.RepositoryAbstracts;
using Data.DAL;
using Data.RepositoryConcretes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Concretes;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IWebHostEnvironment _env;
    private readonly IMapper _mapper;
    private readonly IProductImageRepository _productImageRepository;
    public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IWebHostEnvironment env, IMapper mapper,  IProductImageRepository productImageRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _env = env;
        _mapper = mapper;
        _productImageRepository = productImageRepository;
    }

    public async Task AddProduct(ProductCreateDTO productCreateDTO)
    {
        if (productCreateDTO.ProductPosterImageFile == null) throw new EntityFileNotFoundException("File not found!");
        var existGenre = _categoryRepository.GetEntity(x => x.Id == productCreateDTO.CategoryId);
        if (existGenre == null)
            throw new EntityNotFoundException("Category not found!");
      
        Product product = _mapper.Map<Product>(productCreateDTO);

        ProductImage productImage = new ProductImage
        {
            Product = product,
            ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads/products", productCreateDTO.ProductPosterImageFile, "product"),
            IsPoster = true
        };
        _productImageRepository.AddEntityAsync(productImage);

        foreach (var item in productCreateDTO.ImageFiles)
        {
            ProductImage productImage1 = new ProductImage
            {
                Product = product,
                ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads/products", item, "product"),
                IsPoster = false
            };
            _productImageRepository.AddEntityAsync(productImage1);

        }

       
       
        



        await _productRepository.AddEntityAsync(product);
        await _productRepository.CommitAsync();
    }

    public void DeleteProduct(int id)
    {
        var existProduct = _productRepository.GetEntity(x => x.Id == id);
        if (existProduct == null) throw new EntityNotFoundException("Product not found");
        var existroductImage = _productImageRepository.GetAllEntities(x => x.ProductId == id);
        if (existroductImage == null) throw new EntityNotFoundException("ProductImage not found");
        foreach(var item in existroductImage)
        {
            Helper.DeleteFile(_env.WebRootPath, @"uploads\products", item.ImageUrl);
        }

      
        _productRepository.DeleteEntity(existProduct);
        _productRepository.Commit();
    }

    public List<ProductGetDTO> GetAllProducts(Func<Product, bool>? func = null)
    {
        var products = _productRepository.GetAllEntities(null, "Category","ProductImage");
        List<ProductGetDTO> productsDto = _mapper.Map<List<ProductGetDTO>>(products);

        return productsDto;
    }

    public ProductGetDTO GetProduct(Func<Product, bool>? func = null)
    {
        var product = _productRepository.GetEntity(func,"Category");
        ProductGetDTO productsDto = _mapper.Map<ProductGetDTO>(product);



        return productsDto;
    }

    public void UpdateProduct(ProductUpdateDTO productUpdateDTO)
    {
		var oldProduct = _productRepository.GetEntity(x => x.Id == productUpdateDTO.Id);
		if (oldProduct == null) throw new EntityNotFoundException("Product not found");
        var oldImages = _productImageRepository.GetAllEntities(x => x.ProductId == productUpdateDTO.Id);
        if (oldImages == null) throw new EntityNotFoundException("ProductImage not found");
      


        if (productUpdateDTO.ProductPosterImageFile != null || productUpdateDTO.ImageFiles != null)
        {
            
            ProductImage productImage = new ProductImage
            {
                Product = oldProduct,
                ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads/products", productUpdateDTO.ProductPosterImageFile, "product"),
                IsPoster = true
            };
            _productImageRepository.AddEntityAsync(productImage);

            foreach (var item in productUpdateDTO.ImageFiles)
            {
                ProductImage productImage1 = new ProductImage
                {
                    Product = oldProduct,
                    ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads/products", item, "product"),
                    IsPoster = false
                };
                _productImageRepository.AddEntityAsync(productImage1);
                foreach (var image in oldImages)
                {
                    Helper.DeleteFile(_env.WebRootPath, @"uploads\products", image.ImageUrl);
                }

            }
            
        }

        oldProduct.Name = productUpdateDTO.Name;
		oldProduct.Price = productUpdateDTO.Price;
		oldProduct.CostPrice = productUpdateDTO.CostPrice;
		oldProduct.DiscountPercent = productUpdateDTO.DiscountPercent;
		oldProduct.ShortDescription = productUpdateDTO.ShortDescription;
		oldProduct.Description = productUpdateDTO.Description;
		oldProduct.CategoryId = productUpdateDTO.CategoryId;
		oldProduct.UpdatedDate = DateTime.UtcNow.AddHours(4);


		_productRepository.Commit();

	}
}
