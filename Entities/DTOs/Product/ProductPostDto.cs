using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.Product
{
    public class ProductPostDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public List<IFormFile> formFiles { get; set; }
        public List<ProductParameterGetDto> ProductParameters { get; set; }
        public AppUserGetDto User { get; set; }
        public int CompanyId { get; set; }
        public CompanyGetDto Company { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public string ForwardUrl { get; set; }
        public bool isConfirmed { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<int> ParameterIds { get; set; }


    }
}
