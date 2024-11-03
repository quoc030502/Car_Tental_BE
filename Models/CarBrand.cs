using System.ComponentModel.DataAnnotations.Schema;

namespace basic_api.Models
{
    [Table("car_brands")]
    public class CarBrand
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("brand")]
        public required string Brand { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Car> Cars { get; set; } = [];
    }
}
