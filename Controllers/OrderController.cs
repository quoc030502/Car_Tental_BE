
using basic_api.Interfaces;
using basic_api.Models;
using Microsoft.AspNetCore.Mvc;
using basic_api.Services;
using basic_api.Data;
using basic_api.Dtos;
using basic_api.Middlewares;
using basic_api.Constants;
using Net.payOS.Types;
using System.Management;
using static System.Net.Mime.MediaTypeNames;


namespace basic_api.Controllers
{
    [Route("api/admins/orders")]
    [ApiController]
    public class AdminOrderController(IOrderInterface orderRepo, IConfiguration configuration, Service service) : ControllerBase
    {
        private readonly IOrderInterface _orderRepo = orderRepo;

        private readonly IConfiguration _configuration = configuration;
        private readonly Service _service = service;

        [HttpPut("{id}")]
        [IsAdmin]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateOrderRequest req)
        {
            var order = await _orderRepo.GetOrderById(id);

            if (order == null)
                return NotFound(ErrorMessages.OrderNotFound);

            order.Status = OrderStatus.PendingConfirm;
            foreach (var image in req.Images)
            {
                order.Images.Add(new Image
                {
                    ImageURL = image
                });
            }

            return Ok(order);
        }

        [HttpGet()]
        [IsAdmin]
        public async Task<IActionResult> GetList([FromQuery] UserGetMyOrderRequest req)
        {
            var orders = await _orderRepo.GetAll(req.Status);
            return Ok(orders);
        }

    }

    [Route("/api/users/orders")]
    [ApiController]
    public class UserOrderController(IOrderInterface orderRepo, IUserInterface userRepo, ICarInterface carRepo, IPaymentInterface paymentRepo, IPayOsInterface payOs, ApplicationDBContext context, Service service) : ControllerBase
    {
        private readonly IOrderInterface _orderRepo = orderRepo;
        private readonly IUserInterface _userRepo = userRepo;
        private readonly ICarInterface _carRepo = carRepo;
        private readonly IPaymentInterface _paymentRepo = paymentRepo;
        private readonly IPayOsInterface _payOS = payOs;
        private readonly ApplicationDBContext _context = context;
        private readonly Service _service = service;
        private readonly double _depositPercent = 0.3;

        [HttpPost()]
        [IsUser]
        [IsActive]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest req)
        {
            var user = await _userRepo.GetUserById(int.Parse(HttpContext.Items["ID"].ToString()));

            if (user == null)
                return NotFound(ErrorMessages.UserNotFound);

            if (user.CarRented == 3)
                return BadRequest(ErrorMessages.UserIsInValid);

            if (!user.IsActive && !req.WithDriver)
                return BadRequest(ErrorMessages.AccountIsInactive);


            var car = await _carRepo.GetCarById(req.CarID);
            if (car == null)
                return NotFound(ErrorMessages.CarNotFound);

            var carOrders = new List<CarOrder>
      {
          new() {
              CarID = req.CarID,
              StartDate = req.StartDate,
              EndDate = req.EndDate,
          }
      };

            user.CarRented += 1;

            double hours = req.EndDate.Subtract(req.StartDate).TotalHours;
            int cost;

            if (hours >= 24.0)
            {
                cost = car.PricePerDay * (int)Math.Ceiling(hours / 24.0);
            }
            else
            {
                cost = car.PricePerHour * (int)Math.Ceiling(hours);
            }

            await using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var order = await _orderRepo.Create(_context, new Order
                    {
                        UserID = user.Id,
                        CouponID = req.CouponID,
                        Cost = cost,
                        Deposit = (int)(cost * _depositPercent),
                        Message = req.Message ?? null,
                        CarOrders = carOrders
                    });
                    await _userRepo.Update(_context, user);

                    // var payment = await _payOS.CreatePayment(orderCode, req.CarName, deposit, PaymentType.CarDeposit);

                    // await _paymentRepo.Create(_context, new Payment
                    // {
                    //   OrderCode = orderCode,
                    //   OrderID = order.Id,
                    //   Amount = (int)deposit,
                    //   Type = PaymentType.CarDeposit,
                    //   Bin = payment.bin,
                    //   Currency = payment.currency,
                    //   Status = payment.status,
                    //   CheckoutURL = payment.checkoutUrl,
                    //   QRCode = payment.qrCode
                    // });

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    // Rollback transaction nếu có lỗi
                    await transaction.RollbackAsync();
                    Console.WriteLine($"Transaction failed: {ex.Message}");
                }
            }

            return Ok();
        }
        [HttpGet()]
        [IsUser]
        public async Task<IActionResult> GetMyOrder([FromQuery] UserGetMyOrderRequest? req)
        {
            var orders = await _orderRepo.GetMyOrder(req.Status, int.Parse(HttpContext.Items["ID"].ToString()));

            return Ok(orders);
        }

        [HttpGet("{id}")]
        [IsUser]
        public async Task<IActionResult> GetDetail([FromRoute] int id)
        {
            var order = await _orderRepo.GetOrderById(id);
            if (order == null)
                return NotFound(ErrorMessages.OrderNotFound);

            var res = new DetailOrderResponse
            {
                Id = order.Id,
                UserID = order.UserID,
                CouponID = order.CouponID,
                IsPay = order.IsPay,
                IsDeposit = order.IsDeposit,
                StartDate = order.CarOrders.FirstOrDefault().StartDate,
                EndDate = order.CarOrders.FirstOrDefault().EndDate,
                Cost = order.Cost,
                Status = order.Status,
                Deposit = order.Deposit
            };

            return Ok(res);
        }


        [HttpPut("{id}/confirm")]
        [IsUser]
        public async Task<IActionResult> ConfirmOrder([FromRoute] int id)
        {
            var order = await _orderRepo.GetOrderById(id);
            if (order == null)
                return NotFound(ErrorMessages.OrderNotFound);

            var car = await _carRepo.GetCarById(order.CarOrders.FirstOrDefault().CarID);
            if (car == null)
                return NotFound(ErrorMessages.CarNotFound);

            order.Status = OrderStatus.OrderSuccess;

            var orderCode = _service.NewOrderCode();

            await using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _orderRepo.Update(_context, order);

                    var payment = await _payOS.CreatePayment(orderCode, car.Name, order.Deposit, PaymentType.CarDeposit);

                    await _paymentRepo.Create(_context, new Payment
                    {
                        OrderCode = orderCode,
                        OrderID = order.Id,
                        Amount = order.Deposit,
                        Type = PaymentType.CarDeposit,
                        Bin = payment.bin,
                        Currency = payment.currency,
                        Status = payment.status,
                        CheckoutURL = payment.checkoutUrl,
                        QRCode = payment.qrCode
                    });

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    // Rollback transaction nếu có lỗi
                    await transaction.RollbackAsync();
                    Console.WriteLine($"Transaction failed: {ex.Message}");
                }
            }
            return Ok();
        }
        [HttpPut("{id}/cancel")]
        [IsUser]
        public async Task<IActionResult> CancelOrder([FromRoute] int id)
        {
            var order = await _orderRepo.GetOrderById(id);
            if (order == null)
                return NotFound(ErrorMessages.OrderNotFound);

            order.Status = OrderStatus.Canceled;

            await _orderRepo.Update(_context, order);

            return Ok();
        }
    }


}