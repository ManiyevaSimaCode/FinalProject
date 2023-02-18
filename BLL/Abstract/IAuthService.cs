using Entities.DTOs.Account;

namespace BLL.Abstract
{
    public interface IAuthService
    {
        Task<bool> Register(RegisterDto registerDto);
        Task<bool> Login(LoginDto loginDto);
        Task SignOut();


    }
}
