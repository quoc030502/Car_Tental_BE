using System.Linq.Expressions;
using basic_api.Data;
using basic_api.Interfaces;
using basic_api.Models;
using Microsoft.EntityFrameworkCore;

namespace basic_api.Repository
{
    public class CouponRepository(ApplicationDBContext context) : ICouponInterface
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<Coupon> Create(Coupon coupon)
        {
            await _context.AddAsync(coupon);
            await _context.SaveChangesAsync();

            return coupon;
        }

        public async Task<List<Coupon>> GetAll(Expression<Func<Coupon, bool>> predicate)
        {
            return await _context.Coupons.Where(predicate).ToListAsync();
        }

        public async Task<Coupon?> GetCouponById(int id)
        {
            return await _context.Coupons.FindAsync(id);
        }

        public async Task<Coupon?> Update(Coupon coupon)
        {
            await _context.SaveChangesAsync();

            return coupon;
        }
    }
}
