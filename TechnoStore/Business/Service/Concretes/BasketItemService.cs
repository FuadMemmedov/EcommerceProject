using Business.Exceptions;
using Business.Service.Abstracts;
using Core.Models;
using Core.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Concretes;

public class BasketItemService:IBasketItemService
{
	private readonly IBasketItemRepository _basketItemRepository;

	public BasketItemService(IBasketItemRepository basketItemRepository)
	{
		_basketItemRepository = basketItemRepository;
	}

	public async Task AddBasketItem(BasketItem basketItem)
	{
		await _basketItemRepository.AddEntityAsync(basketItem);
		await _basketItemRepository.CommitAsync();
	}

	public void DeleteBasketItem(int id)
	{
		var existBasketItem = _basketItemRepository.GetEntity(x => x.Id == id);

		if (existBasketItem == null)
			throw new EntityNotFoundException("Basket not found!");

		_basketItemRepository.DeleteEntity(existBasketItem);
	}

	public List<BasketItem> GetAllBasketItems(Func<BasketItem, bool>? func = null)
	{
		return _basketItemRepository.GetAllEntities(func, "Product");
	}

	public BasketItem GetBasketItem(Func<BasketItem, bool>? func = null)
	{
		return _basketItemRepository.GetEntity(func, "Product");
	}

	public void UpdateBasketItem(int id, BasketItem newBasketItem)
	{
		var existBasketItem = _basketItemRepository.GetEntity(x => x.Id == id);

		if (existBasketItem == null)
			throw new EntityNotFoundException("Basket not found!");

		existBasketItem.ProductId = newBasketItem.ProductId;
		existBasketItem.UserId = newBasketItem.UserId;
		existBasketItem.Counter = newBasketItem.Counter;

		_basketItemRepository.Commit();
	}
}
