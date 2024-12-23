
using System.ComponentModel.DataAnnotations;

namespace basic_api.Dtos
{
    public class UserDto
    {
        public required int Id { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
    }
    public class ActiveUserRequest
    {
        [Required(ErrorMessage = "IsActive is required")]
        public required bool IsActive { get; set; }
    }

    public class UpdateUserRequest
    {
        public string? Username { get; set; }
        public string? DrivingLicense { get; set; }
        [RegularExpression(@"^(0[1-9]{1}[0-9]{8}|(\+84[1-9]{1}[0-9]{8}))$",
           ErrorMessage = "Phone number is not valid. It must be 10 digits (0xx...) or start with +84.")]
        [StringLength(15, ErrorMessage = "Phone number must be less than or equal to 15 characters.")]
        public string? Phone { get; set; }
        public string? ImageURL { get; set; }
    }
}
