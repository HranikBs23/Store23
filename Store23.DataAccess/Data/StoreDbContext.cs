using Microsoft.EntityFrameworkCore;
using Store23.Models;

namespace Store23.DataAccess
{
    public class StoreDbContext:DbContext
    {
        //Constructor
        //we need to pass that to base class 
        public StoreDbContext(DbContextOptions<StoreDbContext> options) :base(options)

        {
                
        }

        public DbSet<Category > Categories { get; set; }
         
    }
}
