using Golowinskiy_NewBostil.DAL.Context;
using Golowinskiy_NewBostil.DAL.Entities;
using Golowinskiy_NewBostil.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Golowinskiy_NewBostil.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly GolowinskiyDBContext _db;
        private readonly ILogger _logger;

        public CategoryRepository(GolowinskiyDBContext db, ILogger<CategoryRepository> logger)
        {
            _logger = logger;
            _db = db;
        }

        public async Task<Category> Get(int id)
        {
            return await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Category>> GetAll()
        {
            return await _db.Categories.Where(x => x.Products.Count > 0).Include(x => x.Products).ToListAsync();
        }

        public async Task<List<Category>> GetAllByUser(string userId)
        {
            return await _db.Categories.Include(x => x.Products).Where(x => x.Products.Any(c => c.UserId == userId)).ToListAsync();
        }

        public async Task<Category> GetByParentId(int parentId)
        {
            return await _db.Categories.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == parentId);
        }
    }
}
