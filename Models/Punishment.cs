using System.ComponentModel.DataAnnotations.Schema;

namespace basic_api.Models
{
  [Table("punishments")]
  public class Punishment
  {
    [Column("id")]
    public int Id { get; set; }

    [ForeignKey("punishments_users")]
    [Column("user_id")]
    public int? UserID { get; set; }

    [ForeignKey("punishments_orders")]
    [Column("order_id")]
    public int? OrderID { get; set; }

    [Column("is_pay")]
    public bool IsPay { get; set; } = false;

    [Column("amount")]
    public int Amount { get; set; }

    [Column("reason")]
    public required string Reason { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public User? User { get; set; }
    public Order? Order { get; set; }
    public Payment? Payment { get; set; }
  }
}
