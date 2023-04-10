using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Service.Dto
{
    public class RegisterRequest
    {
        [Required, MinLength(5), MaxLength(100)]
        public string Name { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; }

        [Required, MinLength(8), MaxLength(32)]
        public string Password { get; set; }

        [Required, Compare(nameof(Password)), DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
