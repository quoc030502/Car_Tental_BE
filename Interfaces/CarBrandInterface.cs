using basic_api.Models;

namespace basic_api.Interfaces
{
    public interface ICarBrandInterface
    {
        Task<CarBrand> Create(CarBrand carBrand);
        Task<List<CarBrand>> GetAll();
        Task<CarBrand?> Delete(int id);
    }
}