using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;

namespace Service.Services
{
    public class CityService : Service<City>, ICityService
    {
        public CityService(IUnitOfWork unitOfWork, IRepository<City> repository) : base(unitOfWork, repository)
        {
        }
    }
}