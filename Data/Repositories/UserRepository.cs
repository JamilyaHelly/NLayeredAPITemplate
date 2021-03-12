using Core.Models;
using Core.Repositories;

namespace Data.Repositories
{
    public class UserRepository:Repository<User>,IUserRepository
    {
     private AppDbContext _appDbContext {get=>_context as AppDbContext;}
     public UserRepository(AppDbContext context):base(context)
     {
         
     }

    }
}