using System.ComponentModel.DataAnnotations.Schema;

namespace basic_api.Models
{
    [Table("comments")]
    public class Comment
    {
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("comments_orders")]
        [Column("order_id")]
        public int? OrderID { get; set; }

        [Column("content")]
        public string Content { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public Order? Order { get; set; }
    }
}
