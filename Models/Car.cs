using System.ComponentModel.DataAnnotations.Schema;

namespace basic_api.Models
{
    [Table("cars")]
    public class Car
    {
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("cars_car_types")]
        [Column("car_type_id")]
        public int? CarTypeID { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("license_plate")]
        public string LicensePlate { get; set; } = string.Empty;

        [Column("is_in_use")]
        public bool IsInUse { get; set; }

        [Column("price_per_hour")]
        public int PricePerHour { get; set; }

        [Column("price_per_day")]
        public int PricePerDay { get; set; }

        [Column("image_url")]
        public string? ImageURL { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public CarType? CarType { get; set; }
        public ICollection<Order> Orders { get; set; } = [];
    }
}
