
using System.ComponentModel.DataAnnotations;

namespace basic_api.Dtos
{
    public class UpdateCarTypeRequest
    {
        public string? Type { get; set; }
        public string? Detail { get; set; }
    }

    public class CreateCarTypeRequest
    {
        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; } = string.Empty;
        [Required(ErrorMessage = "Type is required")]

        public string Detail { get; set; } = string.Empty;
    }
}
