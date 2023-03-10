using Entities.DTOs.Paginate;
using Entities.DTOs.SubCategory;

namespace BLL.Abstract
{
    public interface ISubCategoryService
    {
        Task<List<SubCategoryGetDto>> GetAllAsync();
        Task<List<PaginateDto<SubCategoryGetDto>>> GetAllPaginateAsync(int page, int size);
        Task<SubCategoryGetDto> GetByIdAsync(int id);
        Task<SubCategoryGetDto> GetByNameAsync(string Name);
        
        Task CreateAsync(SubCategoryPostDto categoryPostDto);
        Task UpdateAsync(int id, SubCategoryPostDto categoryPostDto);
        Task DeleteByIdAsync(int id);
    }
}
