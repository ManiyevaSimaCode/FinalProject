using Entities.DTOs.Parameter;
using Entities.DTOs.SubCategory;

namespace Entities.DTOs.SubCategoryParameter
{
    public class SubCategoryParameterGetDto
    {
        public int Id { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategoryGetDto  SubCategoryGetDto{ get; set; }
        public int ParameterId { get; set; }
        public ParameterGetDto parameterGetDto { get; set; }
    }
}
