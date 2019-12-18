using Golowinskiy_NewBostil.DAL.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Golowinskiy_NewBostil.DAL.Interfaces
{
    public interface IProductRepository
    {
        Task Add(Product product);
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> GetLastProduct();
        Task Delete(Product product);
        Task Update(Product product);
        Task UpdateAll(List<Product> products);
        Task<List<Product>> GetAllByUser(string userId);
        Task<List<Product>> GetAllByCategory(int categoryId);
        Task<List<Product>> GetAllByUserCategory(int categoryId, string userId);
        Task<List<Product>> GetAllByCateg(int categoryId);
        Task<List<Product>> GetAllByCategUser(int categoryId, string userId);
    }
}
