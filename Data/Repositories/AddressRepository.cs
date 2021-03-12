using Core.Models;
using Core.Repositories;

namespace Data.Repositories
{
    public class AddressRepository :Repository<Address>,IAddressRepository
    {
         private AppDbContext _appDbContext{get=>_context as AppDbContext;}

         public AddressRepository(AppDbContext context): base(context)
         {
             
         }
    }
}