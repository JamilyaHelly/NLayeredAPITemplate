using System.Threading.Tasks;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;

namespace Service.Services
{
    public class CountryService : Service<Country>, ICountryService
    {
        public CountryService(IUnitOfWork unitOfWork, IRepository<Country> repository) : base(unitOfWork, repository)
        {
        }

        public  async Task<Country> GetWithCityByIdAsync(int countryId)
        {
            return await _unitOfWork.Country.GetWithCityByIdAsync(countryId);
        }
    }
}