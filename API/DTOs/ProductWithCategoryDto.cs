using System.Collections.Generic;

namespace API.DTOs
{
    public class ProductWithCategoryDto:ProductDto
    {
        public virtual CategoryDto Category {get;set;}
    }
}