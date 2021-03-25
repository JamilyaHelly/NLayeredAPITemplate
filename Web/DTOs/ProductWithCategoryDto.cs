using System.Collections.Generic;

namespace Web.DTOs
{
    public class ProductWithCategoryDto:ProductDto
    {
        public virtual CategoryDto Category {get;set;}
    }
}