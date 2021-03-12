using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Seeds
{
    public class AddressSeed: IEntityTypeConfiguration<Address>
    {
        private readonly int[]_ids;
        public AddressSeed( int[] ids)
        {
            _ids=ids;
        }

        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasData(new Address{Id=1,HomeNumber="62b",Description="Home address",CityId=_ids[0]});
            builder.HasData(new Address{Id=2,HomeNumber="63b",Description="Home address",CityId=_ids[1]});
        
        }
    }
}