using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
           builder.HasKey(x=>x.Id);
           builder.Property(x=>x.Id);
           builder.Property(x=>x.Name).IsRequired().HasMaxLength(200);
           builder.ToTable("Countries","dbo");

        }
    }
}