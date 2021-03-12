using System.Threading.Tasks;
using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {

         private AppDbContext _appDbContext{get=>_context as AppDbContext;}
         public CategoryRepository(AppDbContext context):base(context)
         {
             
         }
        public async  Task<Category> GetWithProductByIdAsync(int categoryId)
        {
        return await _appDbContext.Categories.Include(x=>x.Products).SingleOrDefaultAsync
        (x=>x.Id==categoryId);
        }
    }
}