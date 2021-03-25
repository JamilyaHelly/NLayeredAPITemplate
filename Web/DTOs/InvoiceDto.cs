using System;

namespace Web.DTOs
{
    public class InvoiceDto
    {
         public int Id { get; set; }
        
        public string Url { get; set; }
        public DateTime Datetime { get; set; }
    }
}