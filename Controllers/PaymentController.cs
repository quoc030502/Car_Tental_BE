using basic_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using basic_api.Data;
using basic_api.Dtos;
using basic_api.Models;
using basic_api.Middlewares;

namespace basic_api.Controllers
{
    [Route("api/admins/payments")]
    [ApiController]
    public class AdminPaymentController(IPaymentInterface paymentRepo) : ControllerBase
    {
        private readonly IPaymentInterface _paymentRepo = paymentRepo;
        [HttpGet()]
        [IsAdmin]
        public async Task<IActionResult> GetList()
        {
            var payments = await _paymentRepo.GetAll();
            var monthlyAmounts = new decimal[12];

            foreach (var payment in payments)
            {
                int monthIndex = payment.CreatedAt.Month - 1;
                monthlyAmounts[monthIndex] += payment.Amount;
            }

            return Ok(monthlyAmounts);
        }

        [HttpGet("payment-by-status")]
        [IsAdmin]
        public async Task<IActionResult> CountByStatus()
        {
            var payments = await _paymentRepo.CountByStatus();

            return Ok(payments);
        }
    }


}