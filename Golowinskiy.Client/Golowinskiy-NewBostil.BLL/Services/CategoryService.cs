using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Golowinskiy_NewBostil.BLL.DTO;
using Golowinskiy_NewBostil.BLL.Interfaces;
using Golowinskiy_NewBostil.DAL.Entities;
using Golowinskiy_NewBostil.DAL.Interfaces;

namespace Golowinskiy_NewBostil.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddChildItem(CategoryDTO parentItem, List<CategoryDTO> listAllCategories)
        {
            List<CategoryDTO> childItems = (
                from a in listAllCategories
                where a.ParentId == parentItem.Id
                select a).ToList();

            foreach (var childItem in childItems)
            {
                if (childItems.Count > 0)
                {
                    parentItem.ListInnerCat.Add(childItem);
                    await AddChildItem(childItem, listAllCategories);
                }
                else
                {
                    continue;
                }
            }
        }

        public List<CategoryDTO> ConvertToDto(List<Category> categories)
        {
            var categoriesDto = new List<CategoryDTO>();
            categoriesDto = _mapper.Map<List<CategoryDTO>>(categories);

            return categoriesDto;
        }

        public async Task<List<CategoryDTO>> GenerateAllCategories(List<CategoryDTO> listCategories)
        {
            List<CategoryDTO> parentsCategories = 
                (from a in listCategories
                where a.ParentId == 0
                select a).ToList();

            foreach (var parentCat in parentsCategories)
            {
                if (parentsCategories.Count > 0)
                {
                    await AddChildItem(parentCat, listCategories);
                }
                else
                {
                    continue;
                }
            }

            return parentsCategories;
        }

        public async Task<List<CategoryDTO>> GetAllCategories()
        {
            var categories = await _repository.GetAll();
            categories = await GetParentsCategories(categories);
            var categoriesDto = ConvertToDto(categories);
            categoriesDto = await GenerateAllCategories(categoriesDto);
            return categoriesDto;
        }

        public async Task<List<Category>> GetParentsCategories(List<Category> categories)
        {
            var outputCategories = new List<Category>();

            foreach (var category in categories)
            {
                outputCategories = await AddParentCategories(outputCategories, category.Id);
            }

            return outputCategories;
        }

        public async Task<List<Category>> AddParentCategories(List<Category> outputCategories, int parentId)
        {
            while (parentId > 0)
            {
                var parentCategory = await _repository.GetByParentId(parentId);

                if (!outputCategories.Contains(parentCategory))
                {
                    outputCategories.Add(parentCategory);
                    parentId = parentCategory.ParentId;
                }
                else
                {
                    break;
                }
            }

            return outputCategories;
        }

        public async Task<List<BreadCrumbDTO>> GetBreadCrumbs(int categoryId)
        {
            var listBreadCrumbs = new List<BreadCrumbDTO>();
            var breadcrumbs = await GenerateBreadCrumbs(listBreadCrumbs, categoryId);
            return breadcrumbs;
        }

        public async Task<List<BreadCrumbDTO>> GenerateBreadCrumbs(List<BreadCrumbDTO> listBreadCrumbs, int categoryId)
        {
            var category = await _repository.Get(categoryId);
            listBreadCrumbs.Add(new BreadCrumbDTO() { Id = category.Id, Name = category.Name });

            if (category.ParentId != 0)
            {
                await GenerateBreadCrumbs(listBreadCrumbs, category.ParentId);
            }

            return listBreadCrumbs;
        }

        public async Task<List<CategoryDTO>> GetUserCategory(string userId)
        {
            var userCategory = await _repository.GetAllByUser(userId);

            foreach (var item in userCategory)
            {
                item.Products = item.Products.Where(x => x.UserId == userId).ToList();
            }

            userCategory = await GetParentsCategories(userCategory);
            var categoriesDto = ConvertToDto(userCategory);
            categoriesDto = await GenerateAllCategories(categoriesDto);

            return categoriesDto;
        }

        public async Task<List<CategoryDTO>> GetNotNullCategories()
        {
            var categories = await _repository.GetNotNull();        
            categories = await GetParentsCategories(categories);
            var categoriesDto = ConvertToDto(categories);
            categoriesDto = await GenerateAllCategories(categoriesDto);
            return categoriesDto;
        }
    }
}
