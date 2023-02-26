using Entities.DTOs.Account;
using Entities.DTOs.Company;
using Entities.DTOs.Product;

namespace SimRaMVC.Models
{
    public class HomeVM
    {
        public RegisterDto RegisterDto { get; set; }
        public LoginDto LoginDto { get; set; }
        public List<ProductGetDto> Products { get; set; }
        public ProductGetDto Product { get; set; }
        public List<CompanyGetDto> Companies { get; set; }
    }
}
