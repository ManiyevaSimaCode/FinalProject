namespace BLL.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryGetDto>> GetAllAsync();
        Task<CategoryGetDto> GetByIdAsync(int id);
        Task<CategoryGetDto> GetByNameAsync(string Name);
        Task CreateAsync(CategoryPostDto categoryPostDto);
        Task UpdateAsync(int id, CategoryPostDto categoryPostDto);
        Task DeleteByIdAsync(int id);
    }
}
