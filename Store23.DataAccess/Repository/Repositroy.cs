using Microsoft.EntityFrameworkCore;
using Store23.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store23.DataAccess.Repository
{
	public class Repositroy<T>: IRepository <T> where T : class
	{
		private readonly StoreDbContext _dbContext;
		internal DbSet<T> dbSet;

        public Repositroy(StoreDbContext db)
        {
			_dbContext = db;
            this.dbSet = _dbContext.Set<T>();
        }
        public void Add(T entity)
		{
			dbSet.Add(entity);
		}

		public IEnumerable<T> GetAll()
		{
			IQueryable<T> query = dbSet;
			return query.ToList();
		}

		public T GetFirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> filter)
		{
			IQueryable<T> query = dbSet;


			query = query.Where(filter);

			return query.FirstOrDefault();
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entity)
		{
			dbSet.RemoveRange(entity);
		}
	}
}
