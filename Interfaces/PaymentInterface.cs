using System.Linq.Expressions;
using basic_api.Data;
using basic_api.Models;

namespace basic_api.Interfaces
{
    public interface IPaymentInterface
    {
        Task<Payment> Create(ApplicationDBContext? context, Payment payment);
        Task<List<Payment>> GetAll();
        Task<Payment?> TakePayment(Expression<Func<Payment, bool>> predicate);
        Task<Payment?> Delete(int id);
        Task<Payment?> Update(Payment payment);
    }
}
