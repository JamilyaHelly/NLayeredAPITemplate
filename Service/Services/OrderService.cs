using System.Threading.Tasks;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;

namespace Service.Services
{
    public class OrderService : Service<Order>, IOrderService
    {
        public OrderService(IUnitOfWork unitOfWork, IRepository<Order> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Order> GetWithOrderItemByIdAsync(int orderId)
        {
            return await _unitOfWork.Order.GetWithOrderItemByIdAsync(orderId);
        }
    }
}