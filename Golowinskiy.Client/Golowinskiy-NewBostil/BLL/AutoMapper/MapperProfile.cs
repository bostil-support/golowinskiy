using AutoMapper;
using Golowinskiy_NewBostil.BLL.DTO;
using Golowinskiy_NewBostil.DAL.Entities;
using System.Linq;

namespace Golowinskiy_NewBostil.BLL.AutoMapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryDTO>()
                .ForMember("Count", opt => opt.MapFrom(c => c.Products.Count));

            CreateMap<RegistrationDTO, User>()
               .ForMember("DisplayName", opt => opt.MapFrom(c => c.UserName))
               .ForMember("DisplayPassword", opt => opt.MapFrom(c => c.Password));

            CreateMap<AdditionalImageDTO, AdditionalImage>();
            CreateMap<AdditionalImage, AdditionalImageDTO>();

            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>()
                     .ForMember("MainImageLink", opt => opt.MapFrom(c => c.MainImage));

            CreateMap<ProductInfoDTO, Product>()
                  .ForMember("MainImage", opt => opt.Ignore())
                  .ForMember("AdditionalImages", opt => opt.Ignore());
            CreateMap<Product, ProductInfoDTO>()
                .ForMember("MainImageLink", opt => opt.MapFrom(c => c.MainImage))
                .ForMember("MainImage", opt => opt.Ignore())
                 .ForMember("AdditionalImages", opt => opt.Ignore())
                .ForMember("AdditionalImagesLinks", opt => opt.MapFrom(c => c.AdditionalImages.Select(x => x.ImageLink)));
            CreateMap<AdditionalImage, AdditionalImageDTO>();
        }
    }
}
