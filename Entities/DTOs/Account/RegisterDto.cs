using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Account
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
       [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
