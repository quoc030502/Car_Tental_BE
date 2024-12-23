
using System.ComponentModel.DataAnnotations;

namespace basic_api.Dtos
{
    public class CarDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string LicensePlate { get; set; }
        public string? ImageURL { get; set; }
        public required int PricePerHour { get; set; }
        public required int PricePerDay { get; set; }
        public required string Fuel { get; set; }
        public required int Seats { get; set; }
    }
    public class UpdateCarRequest
    {
        public string? Name { get; set; }
        public bool? IsInUse { get; set; }
        public int? PricePerHour { get; set; }
        public int? PricePerDay { get; set; }
        public string? ImageURL { get; set; }
    }

    public class CreateCarRequest
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "LicensePlate is required")]
        public string LicensePlate { get; set; } = string.Empty;

        [Required(ErrorMessage = "Fuel is required")]
        public string Fuel { get; set; } = string.Empty;

        [Required(ErrorMessage = "PricePerHour is required")]
        public int PricePerHour { get; set; }
        [Required(ErrorMessage = "PricePerDay is required")]
        public int PricePerDay { get; set; }
        [Required(ErrorMessage = "ImageURL is required")]
        public string ImageURL { get; set; } = string.Empty;
        [Required(ErrorMessage = "CarTypeID is required")]
        public int CarTypeID { get; set; }
        [Required(ErrorMessage = "CarBrandID is required")]
        public int CarBrandID { get; set; }
    }

    public class GetListCarResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? CarBrandID { get; set; }
        public int? CarTypeID { get; set; }
        public string LicensePlate { get; set; } = string.Empty;
        public int Seats { get; set; }
        public bool IsInUse { get; set; }
        public int PricePerDay { get; set; }
        public int PricePerHour { get; set; }
        public string? ImageURL { get; set; } = string.Empty;
        public string Fuel { get; set; } = string.Empty;
        public CarTypeInCarList? CarType { get; set; }
        public CarBrandInCarList? CarBrand { get; set; }
    }

    public class CarTypeInCarList
    {
        public string? Type { get; set; }
    }

    public class CarBrandInCarList
    {
        public string? Brand { get; set; }
    }

    public class UserGetListCarRequest
    {
        public string? CarType { get; set; }
        public bool? IsInUse { get; set; }
        public string? Sort { get; set; }
    }

    public class GuessGetListCarRequest
    {
        public string? CarType { get; set; }
        public string? Sort { get; set; }
    }
    public class UserGetListCarResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Fuel { get; set; } = string.Empty;
        public int? CarTypeID { get; set; }
        public int? CarBrandID { get; set; }
        public int Seats { get; set; }
        public string LicensePlate { get; set; } = string.Empty;
        public bool IsInUse { get; set; }
        public int PricePerDay { get; set; }
        public int PricePerHour { get; set; }
        public string? ImageURL { get; set; } = string.Empty;
        public CarTypeInCarList? CarType { get; set; }
        public CarBrandInCarList? CarBrand { get; set; }
    }

    public class GuessGetListCarResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? CarTypeID { get; set; }
        public string LicensePlate { get; set; } = string.Empty;
        public int PricePerDay { get; set; }
        public int PricePerHour { get; set; }
        public string? ImageURL { get; set; } = string.Empty;
    }
}

