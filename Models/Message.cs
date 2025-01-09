using System.ComponentModel.DataAnnotations.Schema;

namespace basic_api.Models
{
    [Table("messages")]
    public class Message
    {
        [Column("id")]
        public int Id { get; set; }


        [ForeignKey("messages_chats")]
        [Column("chat_id")]
        public int? ChatID { get; set; }

        [ForeignKey("messages_users")]
        [Column("sender_id")]
        public int? SenderID { get; set; }

        [Column("text")]
        public string Text { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public Chat? Chat { get; set; }
    }
}
