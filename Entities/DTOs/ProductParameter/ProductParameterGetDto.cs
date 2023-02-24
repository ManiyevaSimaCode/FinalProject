using Entities.DTOs.Parameter;
using Entities.DTOs.Product;

namespace Entities.DTOs.ProductParameter
{
    public class ProductParameterGetDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductGetDto ProductGetDto { get; set; }
        public int ParameterId { get; set; }
        public ParameterGetDto ParametrGetDto { get; set; }
    }
}
