using System.Linq.Expressions;
using basic_api.Data;
using basic_api.Dtos;
using basic_api.Models;

namespace basic_api.Interfaces
{
    public interface IOrderInterface
    {
        Task<Order> Create(ApplicationDBContext? context, Order Order);
        Task<List<OrderDto>> GetAll(string? status);
        Task<Order?> GetOrderById(int id);
        Task<Order?> Delete(int id);
        Task<Order?> Update(ApplicationDBContext? context, Order Order);
        Task<List<OrderDto>> GetMyOrder(string? status, int? userId);
        Task<List<Order>> CronGetAll(Expression<Func<Order, bool>> predicate);
        Task<Order> GetOrderByUserIDAndCarID(int carID, int userID);
    }
}
