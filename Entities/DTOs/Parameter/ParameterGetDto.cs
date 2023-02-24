
using Entities.DTOs.SubCategoryParameter;

namespace Entities.DTOs.Parameter
{
    public class ParameterGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubCategoryParameterGetDto> SubCategoryParameters { get; set; }
        public List<ProductParameterGetDto> ProductParameters { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
