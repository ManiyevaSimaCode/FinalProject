

using Entities.DTOs.SubCategory;

namespace Entities.DTOs.Category
{
    public class CategoryGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<SubCategoryGetDto>SubCategoryGetDtos { get; set; }
    }
}
