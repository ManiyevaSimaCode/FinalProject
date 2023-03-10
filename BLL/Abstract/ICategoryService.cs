using Entities.DTOs.Paginate;
using Entities.DTOs.SubCategory;

namespace BLL.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryGetDto>> GetAllAsync();
        Task<List<PaginateDto<CategoryGetDto>>> GetAllPaginateAsync(int page,int size);
        Task<CategoryGetDto> GetByIdAsync(int id);
        Task<CategoryGetDto> GetByNameAsync(string Name);
        Task CreateAsync(CategoryPostDto categoryPostDto);
        Task UpdateAsync(int id, CategoryPostDto categoryPostDto);
        Task DeleteByIdAsync(int id);
    }
}
