
using System.ComponentModel.DataAnnotations;

namespace basic_api.Dtos
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public required string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public required string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters")]
        public required string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"^(0[1-9]{1}[0-9]{8}|(\+84[1-9]{1}[0-9]{8}))$",
            ErrorMessage = "Phone number is not valid. It must be 10 digits (0xx...) or start with +84.")]
        [StringLength(15, ErrorMessage = "Phone number must be less than or equal to 15 characters.")]
        public required string Phone { get; set; } = string.Empty;

        public required string DrivingLicense { get; set; } = string.Empty;
    }

    public class LoginModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public required string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required")]
        public required string Password { get; set; } = string.Empty;
    }

    public class GenerateVerifyingCodeRequest
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public required string Email { get; set; } = string.Empty;
    }

    public class VerifyCodeRequest
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public required string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Code is required")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Code must be exactly 6 characters long")]
        public required string Code { get; set; } = string.Empty;
    }

    public class LoginGoogleRequest
    {
        [Required(ErrorMessage = "IDToken is required")]
        public required string IDToken { get; set; }
    }
    public class PasswordVerifyCodeRequest
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public required string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Code is required")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Code must be exactly 6 characters long")]
        public required string Code { get; set; } = string.Empty;
        [Required(ErrorMessage = "Code is required")]
        public required string NewPassword { get; set; } = string.Empty;

    }

}
