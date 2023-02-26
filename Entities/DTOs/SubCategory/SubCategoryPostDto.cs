using Entities.DTOs.Category;
using Entities.DTOs.SubCategoryParameter;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.SubCategory;

public class SubCategoryPostDto
{
    public string Name { get; set; }
    public  int CategoryId { get; set; }
    public CategoryGetDto Category { get; set; }
    public DateTime CreatedDate { get; set; }
    public List<SubCategoryParameterGetDto> SubCategoryParameters { get; set; }
    public List<int> ParameterIds { get; set; }

}
