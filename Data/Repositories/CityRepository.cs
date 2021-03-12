using Core.Models;
using Core.Repositories;

namespace Data.Repositories
{
    public class CityRepository:Repository<City>,ICityRepository
    {
        private AppDbContext _appDbContext{ get=> _context as AppDbContext;}
        public CityRepository(AppDbContext context):base(context)
        {
            
        }
        
    }
}