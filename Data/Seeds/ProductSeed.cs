using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {

        private readonly int[] _ids;
        public ProductSeed(int[]ids)
        {
            _ids=ids;
        }
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product { Id =1, Name = "Nike", Price = 12.5m, Stock = 100, CategoryId = _ids[0] });
            builder.HasData(new Product { Id =2, Name = "Handbag", Price = 50.415m, Stock = 200, CategoryId = _ids[1] });
          
        }
    }
}