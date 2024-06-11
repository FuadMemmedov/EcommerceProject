using Core.Models;
using Core.RepositoryAbstracts;
using Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.RepositoryConcretes;

public class ShopSliderRepository : GenericRepository<ShopSlider>, IShopSliderRepository
{
	public ShopSliderRepository(AppDbContext appDbContext) : base(appDbContext)
	{
	}
}
