using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Seeds
{
    public class CountrySeed : IEntityTypeConfiguration<Country>
    {
        private readonly int[] _ids;
        public CountrySeed(int[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(new Country { Id = _ids[0], Name = "Germany" });
            builder.HasData(new Country { Id = _ids[1], Name = "Turkie" });
        }
    }
}