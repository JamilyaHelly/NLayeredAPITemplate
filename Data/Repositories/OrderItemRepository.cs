using System.Threading.Tasks;
using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class OrderItemRepository : Repository<OrderItem>, IOrdeItemRepository
    {

        private AppDbContext _appDbContext{get=> _context as AppDbContext;}

        public OrderItemRepository(AppDbContext context): base(context)
        {
            
        }
       
    }
}