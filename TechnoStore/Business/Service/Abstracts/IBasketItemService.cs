using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Abstracts;

public interface IBasketItemService
{
	Task AddBasketItem(BasketItem basketItem);
	void DeleteBasketItem(int id);
	List<BasketItem> GetAllBasketItems(Func<BasketItem, bool>? func = null);
	BasketItem GetBasketItem(Func<BasketItem, bool>? func = null);
	void UpdateBasketItem(int id, BasketItem newBasketItem);

}
