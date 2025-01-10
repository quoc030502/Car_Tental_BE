using System.ComponentModel.DataAnnotations.Schema;

namespace basic_api.Models
{
  [Table("payments")]
  public class Payment
  {
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    public required long OrderCode { get; set; }

    [ForeignKey("payments_orders")]
    [Column("order_id")]
    public int? OrderID { get; set; }

    [ForeignKey("payments_punishments")]
    [Column("punishment_id")]
    public int? PunishmentID { get; set; }

    [Column("amount")]
    public int Amount { get; set; }

    [Column("type")]
    public required string Type { get; set; }

    [Column("bin")]
    public required string Bin { get; set; }

    [Column("currency")]
    public required string Currency { get; set; }

    [Column("status")]
    public required string Status { get; set; }

    [Column("checkout_url")]
    public required string CheckoutURL { get; set; }

    [Column("qr_code")]
    public required string QRCode { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Order? Order { get; set; }
    public Punishment? Punishment { get; set; }
  }
}
