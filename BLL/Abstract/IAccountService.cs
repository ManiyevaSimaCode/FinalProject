using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IAccountService
    {
        Task<CategoryGetDto> GetByNameAsync(string Name);
        Task CreateAsync(CategoryPostDto categoryPostDto);
        Task UpdateAsync(int id, CategoryPostDto categoryPostDto);
        Task DeleteByIdAsync(int id);
     

    }
}
