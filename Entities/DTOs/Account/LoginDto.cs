using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Account
{
    public class LoginDto
    {
    //    [Required]
    //    public string UserName { get; set; }
    //    [Required]

        public string Email { get; set; }

        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
