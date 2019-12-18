using Golowinskiy_NewBostil.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Golowinskiy_NewBostil.DAL.Interfaces
{
    public interface IAddtImageRepository
    {
        Task Add(List<AdditionalImage> addtImages);
        Task Delete(AdditionalImage addtImage);
        Task<AdditionalImage> GetById(int id);
    }
}
