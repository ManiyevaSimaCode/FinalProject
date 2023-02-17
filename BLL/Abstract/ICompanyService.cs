using Entities.DTOs.Company;

namespace BLL.Abstract
{
    public interface ICompanyService
    {
        Task<List<CompanyGetDto>> GetAllAsync();
        Task<CompanyGetDto> GetByIdAsync(int id);
        Task<CompanyGetDto> GetByNameAsync(string Name);
        Task CreateAsync(CompanyPostDto categoryPostDto);
        Task UpdateAsync(int id, CompanyPostDto companyPostDto);
        Task DeleteByIdAsync(int id);
    }
}
