using System.Threading.Tasks;
using Core.Repositories;
using Core.UnitOfWorks;
using Data.Repositories;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
       private readonly AppDbContext _context;
       public UnitOfWork(AppDbContext appDbContext)
       {
           _context=appDbContext;
       }
      
         private AddressRepository _addressRepository;
         private CategoryRepository _categoryRepository;
         private CityRepository _cityRepository;
         private CountryRepository _countryRepository;
         private InvoiceRepository _invoiceRepository;
         private OrderItemRepository _orderItemRepository;
         private OrderRepository _orderRepository;
         private ProductRepository _productRepository;
         private UserRepository _userRepository;


        public IAddressRepository Address => _addressRepository=_addressRepository?? new AddressRepository(_context);
        public ICategoryRepository Category => _categoryRepository=_categoryRepository?? new CategoryRepository(_context);
        public ICityRepository City => _cityRepository=_cityRepository?? new CityRepository(_context);
        public ICountryRepository Country =>_countryRepository=_countryRepository?? new CountryRepository(_context);
        public IInvoiceRepository Invoice =>_invoiceRepository=_invoiceRepository?? new InvoiceRepository(_context);
        public IOrderItemRepository OrderItem => _orderItemRepository=_orderItemRepository?? new OrderItemRepository(_context);
        public IOrderRepository Order => _orderRepository=_orderRepository?? new OrderRepository(_context);
        public IProductRepository Product => _productRepository=_productRepository?? new ProductRepository(_context);
        public IUserRepository User => _userRepository=_userRepository?? new UserRepository(_context);

        public void Commit()
        {
           _context.SaveChanges();
        }

        public  async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}