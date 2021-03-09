using System.Threading.Tasks;
using Core.Models;

namespace Core.Repositories
{
    public interface ICountryRepository:IRepository<Country>
    {
        Task<Country> GetWithCityByIdAsync(int countryId);
    }
}