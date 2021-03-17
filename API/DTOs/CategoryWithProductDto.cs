using System.Collections.Generic;

namespace API.DTOs
{
    public class CategoryWithProductDto:CategoryDto
    {
        public ICollection<ProductDto> Products { get; set; }
    }
}