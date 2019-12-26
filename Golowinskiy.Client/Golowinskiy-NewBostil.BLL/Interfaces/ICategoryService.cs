using Golowinskiy_NewBostil.BLL.DTO;
using Golowinskiy_NewBostil.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Golowinskiy_NewBostil.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllCategories();
        Task<List<CategoryDTO>> GetNotNullCategories();
        Task<List<CategoryDTO>> GetUserCategory(string userId);
        Task<List<Category>> GetParentsCategories(List<Category> categories);
        Task<List<Category>> AddParentCategories(List<Category> outputCategories, int parentId);
        Task<List<BreadCrumbDTO>> GetBreadCrumbs(int categoryId);
        Task<List<BreadCrumbDTO>> GenerateBreadCrumbs(List<BreadCrumbDTO> listBreadCrumbs, int categoryId);
        List<CategoryDTO> ConvertToDto(List<Category> categories);
        Task AddChildItem(CategoryDTO parentItem, List<CategoryDTO> listAllCategories);
        Task<List<CategoryDTO>> GenerateAllCategories(List<CategoryDTO> listCategories);
    }
}
