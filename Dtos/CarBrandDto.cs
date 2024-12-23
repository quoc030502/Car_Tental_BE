
using System.ComponentModel.DataAnnotations;

namespace basic_api.Dtos
{
    public class CreateCarBrandRequest
    {
        [Required(ErrorMessage = "Brand is required")]
        public string Brand { get; set; } = string.Empty;
    }
}
