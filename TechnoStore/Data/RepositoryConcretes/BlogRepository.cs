using Core.Models;
using Core.RepositoryAbstracts;
using Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.RepositoryConcretes;

public class BlogRepository : GenericRepository<Blog>, IBlogRepository
{
	public BlogRepository(AppDbContext appDbContext) : base(appDbContext)
	{
	}
}
