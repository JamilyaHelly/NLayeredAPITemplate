using System.Threading.Tasks;
using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {

        private AppDbContext _appDbContext{get=>_context as AppDbContext;}
        public OrderRepository(AppDbContext context):base(context)
        {
            
        }
        public async  Task<Order> GetWithOrderItemByIdAsync(int orderitemId)
        {
            return await _appDbContext.Orders.Include(x=>x.OrderItems).SingleOrDefaultAsync
            (x=>x.Id==orderitemId);
        }
    }
}