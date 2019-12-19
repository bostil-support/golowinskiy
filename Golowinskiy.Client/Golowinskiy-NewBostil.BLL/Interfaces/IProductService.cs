using Golowinskiy_NewBostil.BLL.DTO;
using Golowinskiy_NewBostil.DAL.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Golowinskiy_NewBostil.BLL.Interfaces
{
    public interface IProductService
    {
        Task AddProduct(ProductInfoDTO productDto);
        Task EditProduct(ProductInfoDTO productDto);
        Task<bool> DeleteProduct(int id);
        Task<bool> DeleteAddtImage(int id);
        Task<List<ProductDTO>> GetAllProducts();
        Task<List<ProductInfoDTO>> GetProductsDetail(int categoryId, string userId, bool isChange);
        Task<ProductInfoDTO> GetProductDetailById(int id);
        Task<List<ProductDTO>> GetProductsByUser(string userId);
        Task<List<ProductDTO>> GetProductsByCategory(int categoryId);
        Task<List<ProductDTO>> GetProductsByUserCategory(int categoryId, string userId);
        Task SaveMainImage(IFormFile image, Product lastProduct);
        Task SaveAddtImages(List<IFormFile> additionalImages, Product currentProduct);
    }
}
