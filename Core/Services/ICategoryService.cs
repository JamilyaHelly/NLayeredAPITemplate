using System.Threading.Tasks;
using Core.Models;

namespace Core.Services
{
    public interface ICategoryService:IService<Category>
    {
          Task<Category> GetWithProductByIdAsync(int categoryId);
    }
}