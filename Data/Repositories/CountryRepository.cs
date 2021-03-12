using System.Threading.Tasks;
using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {

         private AppDbContext _appDbContext{get=>_context as AppDbContext;}
         public CountryRepository(AppDbContext context):base(context)
         {
             
         }
        public async Task<Country> GetWithCityByIdAsync(int countryId)
        {
            return await _appDbContext.Countries.Include(x=>x.Cities).SingleOrDefaultAsync(x=>x.Id==countryId);
            
        }
    }
}