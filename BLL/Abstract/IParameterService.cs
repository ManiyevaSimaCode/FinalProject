using Entities.DTOs.Paginate;
using Entities.DTOs.Parameter;

namespace BLL.Abstract
{
    public interface IParameterService
    {
        Task<List<ParameterGetDto>> GetAllAsync();
        Task<List<PaginateDto<ParameterGetDto>>> GetAllPaginateAsync(int page,int size);
        Task<ParameterGetDto> GetByIdAsync(int id);
        Task<ParameterGetDto> GetByNameAsync(string Name);
        Task CreateAsync(ParameterPostDto parameterPostDto);
        Task UpdateAsync(int id, ParameterPostDto parameterPostDto);
        Task DeleteByIdAsync(int id);
    }
}
