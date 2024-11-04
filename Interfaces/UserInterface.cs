using basic_api.Data;
using basic_api.Dtos;
using basic_api.Models;

namespace basic_api.Interfaces
{
    public interface IUserInterface
    {
        Task<User> Create(User user);
        Task<User?> GetUserByEmail(string email);
        Task<List<User>> GetAll();
        Task<User?> GetUserById(int id);
        Task<User?> ActiveUser(int id, ActiveUserRequest req);
        Task<User?> Delete(int id);
        Task<User?> Update(ApplicationDBContext? context, User user);
    }
}
