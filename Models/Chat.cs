using System.ComponentModel.DataAnnotations.Schema;

namespace basic_api.Models
{
    [Table("chats")]
    public class Chat
    {
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("from_user")]
        [Column("from_id")]
        public User? FromID { get; set; }

        [ForeignKey("to_user")]
        [Column("to_id")]
        public User? ToID { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Message> Messages { get; set; } = [];
    }
}