using System.Collections.Generic;

namespace Web.DTOs
{
    public class OrderWithOrderItemDto:OrderDto
    {
        public ICollection<OrderItemDto> OrderItems{get;set;}
    }
}