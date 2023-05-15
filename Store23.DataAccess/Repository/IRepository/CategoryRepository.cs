using Microsoft.EntityFrameworkCore;
using Store23.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store23.DataAccess.Repository.IRepository
{

	public class CategoryRepository : Repositroy<Category>, ICategoryRepository
	{

		private StoreDbContext _dbContext;
		public CategoryRepository(StoreDbContext dbContext) : base (dbContext) 

		{
			_dbContext = dbContext;
		}

		public void Save()
		{
			_dbContext.SaveChanges();
		}

		public void Update(Category obj)
		{
			_dbContext.Update(obj);
		}
	}
}
