using System.Linq.Expressions;
using basic_api.Constants;
using basic_api.Data;
using basic_api.Interfaces;
using basic_api.Models;
using Microsoft.EntityFrameworkCore;

namespace basic_api.Repository
{
    public class PaymentRepository(ApplicationDBContext context) : IPaymentInterface
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<Payment> Create(ApplicationDBContext? context, Payment payment)
        {
            if (context != null)
            {
                await context.AddAsync(payment);
                await context.SaveChangesAsync();
            }
            else
            {
                await _context.AddAsync(payment);
                await _context.SaveChangesAsync();
            }

            return payment;
        }

        public async Task<List<Payment>> GetAll()
        {
            return await _context.Payments.Where(p => p.Status == PaymentStatus.SUCCESS && p.CreatedAt.Year == DateTime.Now.Year).OrderBy(p => p.CreatedAt).Include(p => p.Order).ToListAsync();
        }

        public async Task<Payment?> TakePayment(Expression<Func<Payment, bool>> predicate)
        {
            var payment = await _context.Payments.Include(p => p.Order).ThenInclude(o => o.CarOrders).FirstOrDefaultAsync(predicate);
            return payment;
        }


        public async Task<Payment?> Delete(int id)
        {
            var payment = await _context.Payments.FindAsync(id);

            if (payment == null) return null;

            _context.Payments.Remove(payment);

            await _context.SaveChangesAsync();

            return payment;
        }

        public async Task<Payment?> Update(Payment payment)
        {
            await _context.SaveChangesAsync();

            return payment;
        }

        public async Task<Dictionary<string, int>> CountByStatus()
        {
            return await _context.Payments
            .GroupBy(p => p.Status)
            .Select(g => new { Status = g.Key.ToString(), Count = g.Count() == 0 ? 1 : g.Count() })
            .ToDictionaryAsync(x => x.Status, x => x.Count);
        }
    }
}
