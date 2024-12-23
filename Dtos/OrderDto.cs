
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using basic_api.Constants;
using basic_api.Models;
using basic_api.Validation;

namespace basic_api.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }

        public int? UserID { get; set; }
        public int? CouponID { get; set; }
        public bool IsPay { get; set; } = false;

        public bool IsDeposit { get; set; } = false;

        public bool WithDriver { get; set; } = false;

        public string Status { get; set; } = OrderStatus.New;

        public string? Message { get; set; } = string.Empty;

        public int Cost { get; set; }
        public int Deposit { get; set; }
        public int? Punishment { get; set; }
        public string Contract { get; set; } = string.Empty;
        public string? Evidence { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<Image>? Images { get; set; } = null;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public UserDto? User { get; set; }
        public List<ImageDto>? Image { get; set; }
        public List<CarOrderDto>? CarOrder { get; set; }
    }

    public class CreateOrderRequest
    {
        [Required(ErrorMessage = "CarID is required")]
        public int CarID { get; set; }
        [Required(ErrorMessage = "CarName is required")]
        public required string CarName { get; set; }
        public string? Message { get; set; }
        [Required(ErrorMessage = "WithDriver is required")]
        public required bool WithDriver { get; set; }
        [Required(ErrorMessage = "StartDate is required")]
        [DateRangeValidation("EndDate")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "EndDate is required")]
        public DateTime EndDate { get; set; }
        public int? CouponID { get; set; }
    }

    public class CreateOrderResponse
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int CouponID { get; set; }
        public bool IsApproval { get; set; }
        public bool IsPay { get; set; }
        public bool IsDeposit { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Cost { get; set; }
        public string Status { get; set; } = OrderStatus.New;
        public required string CheckoutUrl { get; set; }
        public required string QRCode { get; set; }
    }

    public class UpdateOrderRequest
    {
        public string[] Images { get; set; } = [];
        public string? Contract { get; set; }
    }

    public class UserGetMyOrderRequest
    {
        public string? Status { get; set; }
    }

    public class DetailOrderResponse
    {
        public int Id { get; set; }
        public int? UserID { get; set; }
        public int? CouponID { get; set; }
        public bool IsApproval { get; set; }
        public bool IsPay { get; set; }
        public bool IsDeposit { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Cost { get; set; }
        public string Status { get; set; } = OrderStatus.New;
        public string? CheckoutUrl { get; set; }
        public string? QRCode { get; set; }
        public int Deposit { get; set; }

    }
    public class ConfirmOrderResponse
    {
        public required string CheckoutURL { get; set; }
        public long OrderCode { get; set; }

    }

    public class ConfirmReturnRequest
    {
        public int? PunishmentAmount { get; set; }
        public string? Reason { get; set; }
        public string? EvidenceImage { get; set; }
    }
    public class CarOrderDto
    {
        public int Id { get; set; }
        public int? CarID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public CarDto? Car { get; set; }
    }
}

