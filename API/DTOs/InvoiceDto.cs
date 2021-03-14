using System;

namespace API.DTOs
{
    public class InvoiceDto
    {
         public int Id { get; set; }
        
        public string Url { get; set; }
        public DateTime Datetime { get; set; }
    }
}