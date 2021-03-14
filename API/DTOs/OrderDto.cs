namespace API.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DeliveryAddressId { get; set; }
        public int BillingAddressId { get; set; }
        public int InvoiceId { get; set; }
    }
}