using basic_api.Dtos;
using basic_api.Models;

namespace basic_api.Interfaces
{
    public interface ICarInterface
    {
        Task<Car> Create(Car car);
        Task<List<GetListCarResponse>> GetAll();
        Task<Car?> GetCarById(int? id);
        Task<Car?> Delete(int id);
        Task<Car?> Update(Car user);
        Task<List<UserGetListCarResponse>> UserGetAll(UserGetListCarRequest req);
        Task<List<GuessGetListCarResponse>> GuessGetAll(GuessGetListCarRequest req);
    }
}