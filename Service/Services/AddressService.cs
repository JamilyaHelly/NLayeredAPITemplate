using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;

namespace Service.Services
{
    public class AddressService :Service<Address>, IAddressService
    {
        public AddressService(IUnitOfWork unitOfWork, IRepository<Address> repository)
        : base(unitOfWork, repository)
        {
        }
    }
}