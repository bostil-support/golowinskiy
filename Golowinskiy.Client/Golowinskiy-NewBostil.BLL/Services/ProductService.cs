using System;
using System.Linq;
using AutoMapper;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Golowinskiy_NewBostil.BLL.DTO;
using Golowinskiy_NewBostil.BLL.Interfaces;
using Golowinskiy_NewBostil.DAL.Entities;
using Golowinskiy_NewBostil.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace Golowinskiy_NewBostil.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IAddtImageRepository _addtImgRepository;
        private readonly IAuthService _authService;
        private readonly IHostEnvironment _env;
        private readonly IMapper _mapper;

        public ProductService(
            IProductRepository productRepository, 
            IAddtImageRepository addtImgRepository,
            IAuthService authService,
            IHostEnvironment env,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _addtImgRepository = addtImgRepository;
            _authService = authService;
            _env = env;
            _mapper = mapper;
        }

        public async Task AddProduct(ProductInfoDTO productDto)
        {
            var newProduct = _mapper.Map<Product>(productDto);
            await _productRepository.Add(newProduct);

            var lastProduct = await _productRepository.GetLastProduct();

            if (productDto.MainImage != null)
            {
                await SaveMainImage(productDto.MainImage, lastProduct);
            }
            else
            {
                lastProduct.MainImage = "/images/noimage.png";
                await _productRepository.Update(lastProduct);
            }

            if (productDto.AdditionalImages != null)
            {
                await SaveAddtImages(productDto.AdditionalImages, lastProduct);
            }
        }

        public async Task<bool> DeleteAddtImage(int id)
        {
            var img = await _addtImgRepository.GetById(id);

            if (img == null)
            {
                return false;
            }

            await _addtImgRepository.Delete(img);

            return true;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                return false;
            }

            await _productRepository.Delete(product);

            if (Directory.Exists(product.MainImage) && product.MainImage != "/images/noimage.png")
            {
                Directory.Delete(product.MainImage);
            }

            return true;
        }

        public async Task EditProduct(ProductInfoDTO productDto)
        {
            var product = await _productRepository.GetById(productDto.Id);

            product.ProductName = productDto.ProductName;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.VideoLink = productDto.VideoLink;
            product.ProductType = productDto.ProductType;
            product.ProductArticle = productDto.ProductArticle;
            product.TransformationMechanism = productDto.TransformationMechanism;

            await _productRepository.Update(product);

            if (productDto.MainImage != null)
            {
                await SaveMainImage(productDto.MainImage, product);
            }
            else if (product.MainImage == null)
            {
                product.MainImage = "/images/noimage.png";
                await _productRepository.Update(product);
            }

            if (productDto.AdditionalImages != null)
            {
                await SaveAddtImages(productDto.AdditionalImages, product);
            }
        }

        public async Task SaveMainImage(IFormFile image, Product lastProduct)
        {
            var webRoot = _env.ContentRootPath;
            var path = Path.Combine(webRoot, "wwwroot", "images", "products", lastProduct.Id.ToString());
            if (!Directory.Exists(path))
            {
                DirectoryInfo dir = Directory.CreateDirectory(path);
            }

            var stream = new FileStream(Path.Combine(path, image.FileName), FileMode.Create);
            stream.Position = 0;
            await image.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();

            lastProduct.MainImage = "/images/products/" + lastProduct.Id.ToString() + "/" + image.FileName;
            await _productRepository.Update(lastProduct);
        }

        public async Task SaveAddtImages(List<IFormFile> additionalImages, Product lastProduct)
        {
            int productId = lastProduct.Id;
            var webRoot = _env.ContentRootPath;
            var path = Path.Combine(webRoot, "wwwroot", "images", "products", productId.ToString(), "additionalImages");
            if (!Directory.Exists(path))
            {
                DirectoryInfo dir = Directory.CreateDirectory(path);
            }

            var addtImages = new List<AdditionalImage>();
            foreach (var img in additionalImages)
            {
                var stream = new FileStream(Path.Combine(path, img.FileName), FileMode.Create);
                await img.CopyToAsync(stream);

                var newImage = new AdditionalImage()
                {
                    ProductId = productId,
                    ImageLink = "/images/products/" + lastProduct.Id.ToString() + "/additionalImages/" + img.FileName
                };

                addtImages.Add(newImage);
                stream.Close();
            }

            await _addtImgRepository.Add(addtImages);
        }

        public async Task<List<ProductDTO>> GetProductsByCategory(int categoryId)
        {
            var products = await _productRepository.GetAllByCategory(categoryId);
            var productsDto = new List<ProductDTO>();
            productsDto = _mapper.Map<List<ProductDTO>>(products);

            var users = await _authService.GetAll();

            foreach (var user in users)
            {
                var productsDtoUser = productsDto.Where(x => x.UserId == user.Id);

                foreach(var item in productsDtoUser)
                {
                    item.Coefficient = user.Coefficient;
                }
            }

            foreach (var prod in productsDto)
            {
                prod.Price *= prod.Coefficient;
            }

            return productsDto;
        }

        public async Task<List<ProductDTO>> GetProductsByUserCategory(int categoryId, string userId)
        {
            var products = await _productRepository.GetAllByUserCategory(categoryId, userId);
            var productsDto = new List<ProductDTO>();
            productsDto = _mapper.Map<List<ProductDTO>>(products);

            var users = await _authService.GetAll();

            foreach (var user in users)
            {
                var productsDtoUser = productsDto.Where(x => x.UserId == user.Id);

                foreach (var item in productsDtoUser)
                {
                    item.Coefficient = user.Coefficient;
                }
            }

            return productsDto;
        }

        public async Task<ProductInfoDTO> GetProductDetailById(int id)
        {
            var product = await _productRepository.GetById(id);

            var addtImgsDictionary = new Dictionary<int, string>();
            foreach (var img in product.AdditionalImages)
            {
                addtImgsDictionary.Add(img.Id, img.ImageLink);
            }

            var productDto = _mapper.Map<ProductInfoDTO>(product);
            productDto.AdditionalDictImagesLinks = addtImgsDictionary;
                
            return productDto;
        }

        public async Task<List<ProductDTO>> GetAllProducts()
        {
            var products = await _productRepository.GetAll();
            var productsDto = new List<ProductDTO>();
            productsDto = _mapper.Map<List<ProductDTO>>(products);

            var users = await _authService.GetAll();
            foreach (var user in users)
            {
                var productsDtoUser = productsDto.Where(x => x.UserId == user.Id);

                foreach (var item in productsDtoUser)
                {
                    item.Coefficient = user.Coefficient;
                }
            }

            return productsDto;
        }

        public async Task<List<ProductInfoDTO>> GetProductsDetail(int categoryId, string userId, bool isChange)
        {
            var products = new List<Product>();

            if (isChange)
            {
                products = await _productRepository.GetAllByCategUser(categoryId, userId);
            }
            else
            {
                products = await _productRepository.GetAllByCateg(categoryId);
            }

            var listProductsDeatilDto = new List<ProductInfoDTO>();

            foreach (var prod in products)
            {
                List<string> addtImgs = new List<string>();
                foreach (var img in prod.AdditionalImages)
                {
                    addtImgs.Add(img.ImageLink);
                }

                var productDeatilDto = _mapper.Map<ProductInfoDTO>(prod);

                if (isChange)
                {
                    productDeatilDto.IsChange = true;
                }
                else
                {
                    productDeatilDto.Coefficient = await _authService.GetCoefficient(productDeatilDto.UserId);
                    productDeatilDto.Price *= productDeatilDto.Coefficient;
                    productDeatilDto.AdditionalImagesLinks = addtImgs;
                }


                listProductsDeatilDto.Add(productDeatilDto);
            }

            return listProductsDeatilDto;
        }

        public async Task<List<ProductDTO>> GetProductsByUser(string userId)
        {
            var products = await _productRepository.GetAllByUser(userId);
            var productsDto = new List<ProductDTO>();
            productsDto = _mapper.Map<List<ProductDTO>>(products);

            return productsDto;
        }
    }
}
