using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;

namespace Service.Services
{
    public class OrderItemService : Service<OrderItem>, IOrderItemService
    {
        public OrderItemService(IUnitOfWork unitOfWork, IRepository<OrderItem> repository) : base(unitOfWork, repository)
        {
        }
    }
}