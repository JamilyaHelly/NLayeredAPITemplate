using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Seeds
{
    public class CitySeed : IEntityTypeConfiguration<City>
    {

        private readonly int[] _ids;
        public CitySeed(int[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(new City { Id = _ids[0], Name = "Hamburg", PostCode = 20125, CountryId = _ids[0] });
            builder.HasData(new City { Id = _ids[1], Name = "İstanbul", PostCode = 34598, CountryId = _ids[1] });


        }
    }
}