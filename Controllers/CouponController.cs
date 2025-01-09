using basic_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using basic_api.Data;
using basic_api.Dtos;
using basic_api.Models;
using basic_api.Middlewares;
using basic_api.Services;

namespace basic_api.Controllers
{
    [Route("api/admins/coupons")]
    [ApiController]
    public class AdminCouponController(ICouponInterface couponRepo, Service service) : ControllerBase
    {
        private readonly ICouponInterface _couponRepo = couponRepo;
        private readonly Service _service = service;

        [HttpGet()]
        [IsAdmin]
        public async Task<IActionResult> GetList()
        {
            var coupons = await _couponRepo.GetAll(c => true);
            return Ok(coupons);
        }

        [HttpPut("{id}")]
        [IsAdmin]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCouponRequest req)
        {
            var coupon = await _couponRepo.GetCouponById(id);

            if (coupon == null) return NotFound(ErrorMessages.UserNotFound);

            coupon.IsActive = req.IsActive;

            await _couponRepo.Update(coupon);

            return Ok();
        }

        [HttpPost()]
        [IsAdmin]
        public async Task<IActionResult> Create([FromBody] CreateCouponRequest req)
        {
            var coupon = await _couponRepo.Create(
                    new Coupon
                    {
                        Name = req.Name,
                        DiscountPercent = req.DiscountPercent,
                        IsActive = req.IsActive
                    }
            );

            return Ok(coupon);
        }
    }

    [Route("api/users/coupons")]
    [ApiController]
    public class UserCouponController(ICouponInterface couponRepo) : ControllerBase
    {
        private readonly ICouponInterface _couponRepo = couponRepo;

        [HttpGet()]
        public async Task<IActionResult> GetList()
        {
            var coupons = await _couponRepo.GetAll(p => p.IsActive == true);
            return Ok(coupons);
        }
    }
}