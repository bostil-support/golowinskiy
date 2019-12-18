using Golowinskiy_NewBostil.DAL.Context;
using Golowinskiy_NewBostil.DAL.Entities;
using Golowinskiy_NewBostil.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Golowinskiy_NewBostil.DAL.Repositories
{
    public class AdditionalImageRepository : IAddtImageRepository
    {
        private readonly GolowinskiyDBContext _db;

        public AdditionalImageRepository(GolowinskiyDBContext db)
        {
            _db = db;
        }

        public async Task Add(List<AdditionalImage> addtImages)
        {
            await _db.AdditionalImages.AddRangeAsync(addtImages);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(AdditionalImage addtImage)
        {
            _db.AdditionalImages.Remove(addtImage);
            await _db.SaveChangesAsync();
        }

        public async Task<AdditionalImage> GetById(int id)
        {
            return await _db.AdditionalImages.FindAsync(id);
        }
    }
}
