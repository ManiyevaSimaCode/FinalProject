using Entities.DTOs.Parameter;
using Entities.DTOs.SubCategory;

namespace Entities.DTOs.SubCategoryParameter
{
    public class SubCategoryParameterGetDto
    {
        public int Id { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategoryGetDto  SubCategory{ get; set; }
        public int ParameterId { get; set; }
        public ParameterGetDto Parameter { get; set; }
    }
}
