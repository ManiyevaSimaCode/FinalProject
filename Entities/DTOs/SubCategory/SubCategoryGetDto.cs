using Entities.DTOs.Category;

namespace Entities.DTOs.SubCategory;

public class SubCategoryGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public CategoryGetDto CategoryGetDto { get; set; }
    public DateTime CreatedDate { get; set; }

}
