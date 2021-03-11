using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x=>x.Id);
           builder.Property(x=>x.Id).UseIdentityColumn();
           builder.Property(x=>x.Name).IsRequired().HasMaxLength(200);
           builder.Property(x=>x.Stock).IsRequired();
           //4582174.23 18 karakter(sayı) vırgulden sonra 2 karakter alabılır 
           builder.Property(x=>x.Price).IsRequired().HasColumnType("decimal(18,2)");
           builder.Property(x=>x.InnerBarcode).HasMaxLength(50);
           builder.ToTable("Products","dbo");
        }
    }
}