using System.Threading.Tasks;
using Core.Models;

namespace Core.Services
{
    public interface IOrderService : IService<Order>
    {
        Task<Order> GetWithOrderItemByIdAsync(int orderitemId);
    }
}
