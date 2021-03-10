using System.Threading.Tasks;
using Core.Models;

namespace Core.Services
{
    public interface ICountryService : IService<Country>
    {
        Task<Country> GetWithCityByIdAsync(int countryId);
    }
}
