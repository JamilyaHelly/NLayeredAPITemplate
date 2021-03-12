using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {

        private readonly int[] _ids;
      public CategorySeed( int[] ids)
      {
          _ids=ids;
      }

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category{Id=_ids[0],Name="Shues"});
            builder.HasData(new Category{Id=_ids[1],Name="Bags"});
        }
    }
}