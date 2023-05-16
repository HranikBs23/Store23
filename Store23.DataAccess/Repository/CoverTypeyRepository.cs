using Microsoft.EntityFrameworkCore;
using Store23.DataAccess.Repository.IRepository;
using Store23.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store23.DataAccess.Repository
{

    public class CoverTypeRepository : Repositroy<CoverType>, ICoverTypeRepository
    {

        private  readonly StoreDbContext _dbContext;
        public CoverTypeRepository(StoreDbContext dbContext) : base(dbContext)

        {
            _dbContext = dbContext;
        }

        

        public void Update(CoverType obj)
        {
            _dbContext.CoverTypes.Update(obj);
        }
    }
}
