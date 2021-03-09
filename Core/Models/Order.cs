using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Core.Models
{
    public class Order
    {
        public Order()
        {
            OrderItems= new Collection<OrderItem>();
        }
        public int  Id { get; set; }     
        public int  UserId { get; set; }
        public virtual  User User { get; set; } 
        public int  DeliveryAddressId { get; set; }
        public virtual  Address DeliveryAddress { get; set; }
        public int  BillingAddressId { get; set; }
        public virtual  Address BillingAddress { get; set; }
        public int    InvoiceId { get; set; }
        public virtual  Invoice Invoice { get; set; }
        public ICollection <OrderItem> OrderItems { get; set; }

        
        
    }
}