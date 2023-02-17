using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.Company
{
    public class CompanyPostDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile formFile { get; set; }
        public string InstagramUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public List<Product> Products { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}