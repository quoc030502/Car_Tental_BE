using System.ComponentModel.DataAnnotations.Schema;

namespace basic_api.Models
{
    [Table("images")]
    public class Image
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("image_url")]
        public string ImageURL { get; set; } = string.Empty;

        [Column("type")]
        public required string Type { get; set; } = string.Empty;

        [ForeignKey("images_orders")]
        [Column("order_id")]
        public int? OrderID { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public Order? Order { get; set; }
    }
}
