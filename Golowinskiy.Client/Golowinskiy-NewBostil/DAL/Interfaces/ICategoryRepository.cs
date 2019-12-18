using Golowinskiy_NewBostil.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Golowinskiy_NewBostil.DAL.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> Get(int id);
        Task<List<Category>> GetAll();
        Task<List<Category>> GetAllByUser(string userId);
        Task<Category> GetByParentId(int parentId);
    }
}
