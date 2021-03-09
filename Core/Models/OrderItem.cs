using System;

namespace Core.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public DateTime Datetime { get; set; }
        public int ProductQuantity { get; set; }
        public double ProductPrice { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int OderId { get; set; }
        public virtual Order Order { get; set; }











    }
}