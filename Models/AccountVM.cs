using Entities.DTOs.Account;
using Entities.DTOs.AppUser;

namespace SimRaMVC.Models
{
    public class AccountVM
    {
        public AppUserGetDto AppUser { get; set; }
        public RegisterDto registerDto { get; set; }
    }
}
