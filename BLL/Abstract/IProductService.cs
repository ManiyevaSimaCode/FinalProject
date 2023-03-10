using Entities.DTOs.Paginate;
using Entities.DTOs.Product;

namespace BLL.Abstract
{
    public interface IProductService
    {

        Task<List<ProductGetDto>> GetAllAsync();
        Task<List<PaginateDto<ProductGetDto>>> GetAllPaginateAsync(int page, int size);
        Task<ProductGetDto> GetByIdAsync(int id);
        Task<ProductGetDto> GetByNameAsync(string Name);
        Task CreateAsync(ProductPostDto productPostDto);
        Task UpdateAsync(int id, ProductPostDto productPostDto);
        Task DeleteByIdAsync(int id);
    }
}
