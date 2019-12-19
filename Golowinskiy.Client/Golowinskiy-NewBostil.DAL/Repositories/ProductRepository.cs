using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Golowinskiy_NewBostil.DAL.Context;
using Golowinskiy_NewBostil.DAL.Entities;
using Golowinskiy_NewBostil.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Golowinskiy_NewBostil.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly GolowinskiyDBContext _db;

        public ProductRepository(GolowinskiyDBContext db)
        {
            _db = db;
        }

        public async Task Add(Product product)
        {
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _db.Products.Include(x => x.AdditionalImages).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> GetLastProduct()
        {
            var products = await _db.Products.ToListAsync();
            return  products.LastOrDefault();
        }

        public async Task<List<Product>> GetAll()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<List<Product>> GetAllByUserCategory(int categoryId, string userId)
        {
            return await _db.Products
                .Where(x => x.CategoryId == categoryId && x.UserId == userId)
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<List<Product>> GetAllByCategory(int categoryId)
        {
            return await _db.Products
                .Where(x => x.CategoryId == categoryId)
                .Include(x => x.User).ToListAsync();
        }

        public async Task<List<Product>> GetAllByCateg(int categoryId)
        {
            return await _db.Products.Include(x => x.AdditionalImages)
                .Where(x => x.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<List<Product>> GetAllByCategUser(int categoryId, string userId)
        {
            return await _db.Products.Include(x => x.AdditionalImages)
                .Where(x => x.CategoryId == categoryId && x.UserId == userId)
                .ToListAsync();
        }

        public async Task Delete(Product product)
        {
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAll(List<Product> products)
        {
            _db.Products.UpdateRange(products);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllByUser(string userId)
        {
            return await _db.Products.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
