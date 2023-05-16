using Microsoft.EntityFrameworkCore.Diagnostics;
using Store23.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store23.DataAccess.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly StoreDbContext _dbContext;
        public UnitOfWork(StoreDbContext dbContext) 
        {
			_dbContext = dbContext;
			Category = new CategoryRepository(_dbContext);
			CoverType = new CoverTypeRepository(_dbContext);	
        }
        public ICategoryRepository Category { get; private set; }

		public ICoverTypeRepository CoverType { get; private set; }

		public void Save()
		{
			_dbContext.SaveChanges();
		}
	}
}
