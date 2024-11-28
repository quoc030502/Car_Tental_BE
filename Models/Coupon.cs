using System.ComponentModel.DataAnnotations.Schema;

namespace basic_api.Models
{
    [Table("coupons")]
    public class Coupon
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("code")]
        public int? Code { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        [Column("discount_percent")]
        public int DiscountPercent { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Order> Orders { get; set; } = [];
    }
}
