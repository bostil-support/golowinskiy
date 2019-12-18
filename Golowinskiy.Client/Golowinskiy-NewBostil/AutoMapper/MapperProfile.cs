using AutoMapper;
using Golowinskiy_NewBostil.BLL.DTO;
using Golowinskiy_NewBostil.Models.Category;
using Golowinskiy_NewBostil.Models.Auth;
using Golowinskiy_NewBostil.Models.Product;

namespace Golowinskiy_NewBostil.AutoMapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<CategoryDTO, CategoryViewModel>();

            CreateMap<LoginViewModel, LoginDTO>();
            CreateMap<RegistrationViewModel, RegistrationDTO>();

            CreateMap<BreadCrumbDTO, BreadCrumbViewModel>();

            CreateMap<LoginDTO, LoginViewModel>();
            CreateMap<LoginViewModel, LoginDTO>();

            CreateMap<EditProductViewModel, ProductInfoDTO>();
            CreateMap<ProductInfoDTO, EditProductViewModel>();
            CreateMap<ProductInfoDTO, ProductDetailViewModel>();

            CreateMap<ProductDTO, EditProductViewModel>();
            CreateMap<ProductDTO, ProductDetailViewModel>();
            CreateMap<ProductDTO, ProductCategoryViewModel>();
        }
    }
}
