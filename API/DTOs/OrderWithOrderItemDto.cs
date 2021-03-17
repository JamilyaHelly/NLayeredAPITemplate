using System.Collections.Generic;

namespace API.DTOs
{
    public class OrderWithOrderItemDto:OrderDto
    {
        public ICollection<OrderItemDto> OrderItems{get;set;}
    }
}