using Entities.DTOs.Category;
using Entities.DTOs.Parameter;
using Entities.DTOs.SubCategoryParameter;

namespace Entities.DTOs.SubCategory;

public class SubCategoryGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }

    public CategoryGetDto Category { get; set; }
    public DateTime CreatedDate { get; set; }
    public List<SubCategoryParameterGetDto> SubCategoryParameters { get; set; }
    public List<int>ParameterIds { get; set; }

}
