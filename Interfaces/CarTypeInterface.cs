using basic_api.Models;

namespace basic_api.Interfaces
{
    public interface ICarTypeInterface
    {
        Task<CarType> Create(CarType carType);
        Task<List<CarType>> GetAll();
        Task<CarType?> GetCarTypeById(int id);
        Task<CarType?> Delete(int id);
        Task<CarType?> Update(CarType carType);
        Task<List<CarType>> GuessGetAll();
    }
}