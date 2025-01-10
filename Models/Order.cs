using System.ComponentModel.DataAnnotations.Schema;
using basic_api.Constants;

namespace basic_api.Models
{
  [Table("orders")]
  public class Order
  {
    [Column("id")]
    public int Id { get; set; }

    [ForeignKey("orders_users")]
    [Column("user_id")]
    public int? UserID { get; set; }

    [ForeignKey("orders_coupons")]
    [Column("coupon_id")]
    public int? CouponID { get; set; }

    [Column("is_pay")]
    public bool IsPay { get; set; } = false;

    [Column("is_deposit")]
    public bool IsDeposit { get; set; } = false;

    [Column("is_punish")]
    public bool IsPunish { get; set; } = false;

    [Column("with_driver")]
    public bool WithDriver { get; set; } = false;

    [Column("status")]
    public string Status { get; set; } = OrderStatus.New;

    [Column("message")]
    public string? Message { get; set; } = string.Empty;

    [Column("cost")]
    public int Cost { get; set; }
    [Column("deposit")]
    public int Deposit { get; set; }

    [Column("contract")]
    public string? Contract { get; set; } = string.Empty;

    [Column("evidence")]
    public string? Evidence { get; set; } = string.Empty;
    [Column("driving_cost")]
    public int DrivingCost { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Coupon? Coupons { get; set; }
    public ICollection<Image> Images { get; set; } = [];
    public ICollection<CarOrder> CarOrders { get; set; } = [];
    public ICollection<Payment> Payments { get; set; } = [];
    public Punishment? Punishment { get; set; }
    public User? User { get; set; }
  }
}
