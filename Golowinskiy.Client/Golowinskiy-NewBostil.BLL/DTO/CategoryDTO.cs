using System.Collections.Generic;

namespace Golowinskiy_NewBostil.BLL.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }

        public List<CategoryDTO> ListInnerCat { get; set; } = new List<CategoryDTO>();
    }
}
