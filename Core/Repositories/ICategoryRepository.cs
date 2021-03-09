using System.Threading.Tasks;
using Core.Models;

namespace Core.Repositories
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Task<Category> GetWithProductByIdAsync(int categoryId);
    }
}