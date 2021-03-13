using System.Threading.Tasks;
using Core.Repositories;

namespace Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
         IAddressRepository Address{get;}
         ICategoryRepository Category{get;}
         ICityRepository City{get;}
         ICountryRepository  Country{get;}
         IInvoiceRepository Invoice{get;}
         IOrderItemRepository OrderItem {get;}
         IOrderRepository Order {get;}
         IProductRepository Product{ get;}
         IUserRepository User{get;}
         Task CommitAsync();
         void Commit();
    }
}