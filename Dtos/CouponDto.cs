
using System.ComponentModel.DataAnnotations;

namespace basic_api.Dtos
{
    public class UpdateCouponRequest
    {
        [Required(ErrorMessage = "IsActive is required")]
        public bool IsActive { get; set; }
    }

    public class CreateCouponRequest
    {
        [Required(ErrorMessage = "DiscountPercent is required")]
        [Range(1, 99, ErrorMessage = "DiscountPercent must be between 1 and 99.")]
        public int DiscountPercent { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public required string Name { get; set; }
    }
}
