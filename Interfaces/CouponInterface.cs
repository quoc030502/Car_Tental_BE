using System.Linq.Expressions;
using basic_api.Models;

namespace basic_api.Interfaces
{
    public interface ICouponInterface
    {
        Task<Coupon> Create(Coupon coupon);
        Task<List<Coupon>> GetAll(Expression<Func<Coupon, bool>> predicate);
        Task<Coupon?> Update(Coupon coupon);
        Task<Coupon?> GetCouponById(int id);
    }
}