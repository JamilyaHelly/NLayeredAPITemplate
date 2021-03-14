using System;

namespace API.DTOs
{
    public class OrderItemDto
    {
         public int Id { get; set; }
        public DateTime Datetime { get; set; }
        public int ProductQuantity { get; set; }
        public double ProductPrice { get; set; }
         public int ProductId { get; set; }
         public int OderId { get; set; }
    }
}