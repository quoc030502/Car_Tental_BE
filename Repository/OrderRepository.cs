using basic_api.Data;
using basic_api.Interfaces;
using basic_api.Models;
using Microsoft.EntityFrameworkCore;

namespace basic_api.Repository
{
    public class OrderRepository(ApplicationDBContext context) : IOrderInterface
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<Order> Create(ApplicationDBContext? context, Order Order)
        {
            if (context != null)
            {
                await context.AddAsync(Order);
                await context.SaveChangesAsync();
            }
            else
            {
                await _context.AddAsync(Order);
                await _context.SaveChangesAsync();
            }

            return Order;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<List<Order>> GetMyOrder(string? status, int? userId)
        {
            var db = _context.Orders.AsQueryable();

            if (status != null)
                db = db.Where(o => o.Status == status);



            var orders = await db
              .Where(o => o.UserID == userId)
              .ToListAsync();

            return orders;
        }

        public async Task<Order?> GetOrderById(int id)
        {
            return await _context.Orders.
            Include(o => o.CarOrders).
            FirstOrDefaultAsync(o => o.Id == id);
        }


        public async Task<Order?> Delete(int id)
        {
            var Order = await _context.Orders.FindAsync(id);

            if (Order == null) return null;

            _context.Orders.Remove(Order);

            await _context.SaveChangesAsync();

            return Order;
        }

        public async Task<Order?> Update(ApplicationDBContext? context, Order Order)
        {
            if (context != null)
            {
                await context.SaveChangesAsync();
            }
            else
            {
                await _context.SaveChangesAsync();
            }

            return Order;
        }
    }
}