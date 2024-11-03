using System.ComponentModel.DataAnnotations.Schema;

namespace basic_api.Models
{
    [Table("car_types")]
    public class CarType
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("type")]
        public string Type { get; set; } = string.Empty;

        [Column("detail")]
        public string Detail { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Car> Cars { get; set; } = [];
    }
}
