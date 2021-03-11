using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
             builder.HasKey(x=>x.Id);
           builder.Property(x=>x.Id).UseIdentityColumn();
           builder.Property(x=>x.Name).IsRequired().HasMaxLength(200);
           builder.Property(x=>x.Surname).IsRequired().HasMaxLength(200);
           //4582174.23 18 karakter(sayı) vırgulden sonra 2 karakter alabılır 
           builder.Property(x=>x.IdentityNumber).IsRequired().HasMaxLength(200);
           builder.Property(x=>x.TelefonNumber).IsRequired().HasMaxLength(200);
           builder.ToTable("Users","dbo");
        }
    }
}