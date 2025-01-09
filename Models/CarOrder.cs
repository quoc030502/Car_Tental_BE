using System.ComponentModel.DataAnnotations.Schema;

namespace basic_api.Models
{
    [Table("car_orders")]
    public class CarOrder
    {
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("car_orders_orders")]
        [Column("order_id")]
        public int? OrderID { get; set; }

        [ForeignKey("car_orders_cars")]
        [Column("car_id")]
        public int? CarID { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        public DateTime EndDate { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public Order? Order { get; set; }
        public Car? Car { get; set; }
    }
}
