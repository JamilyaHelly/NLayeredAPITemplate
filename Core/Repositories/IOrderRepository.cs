using System.Threading.Tasks;
using Core.Models;

namespace Core.Repositories
{
    public interface IOrderRepository:IRepository<Order>
    {

        Task<Order> GetWithOrderItemByIdAsync(int orderitemId);
        
    }
}