
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
using Microsoft.VisualBasic;


namespace basic_api.Controllers
{
  [Route("api/admins/orders")]
  [ApiController]
  public class AdminOrderController(IOrderInterface orderRepo, IUserInterface userRepo, IConfiguration configuration, Service service) : ControllerBase
  {
    private readonly IOrderInterface _orderRepo = orderRepo;
    private readonly IUserInterface _userRepo = userRepo;
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
      order.Contract = req.Contract ?? "";

      foreach (var image in req.Images)
      {
        order.Images.Add(new Image
        {
          ImageURL = image,
          Type = OrderImageType.Confirm
        });
      }

      await _orderRepo.Update(null, order);

      var user = await _userRepo.GetUserById(order.UserID);

      if (user == null)
        return BadRequest(ErrorMessages.UserNotFound);

      await _service.SendEmailContract(user.Email, user.Username);

      return Ok(order);
    }

    [HttpPut("{id}/confirm-return")]
    [IsAdmin]
    public async Task<IActionResult> ConfirmReturn([FromRoute] int id, [FromBody] ConfirmReturnRequest req)
    {
      var order = await _orderRepo.GetOrderById(id);

      if (order == null)
        return NotFound(ErrorMessages.OrderNotFound);

      if (order.Status != OrderStatus.PendingReturn)
        return BadRequest(ErrorMessages.OrderNotValid);

      order.Status = OrderStatus.Returning;

      if (req.PunishmentAmount != null)
      {
        var user = await _userRepo.GetUserById(order.UserID);
        if (user == null)
          return NotFound(ErrorMessages.UserNotFound);
        user.IsLock = true;
        order.User = user;
        order.Punishment = new Punishment
        {
          IsPay = false,
          Amount = (int)req.PunishmentAmount,
          Reason = req.Reason ?? ""
        };
      }

      order.Evidence = req.EvidenceImage ?? null;

      await _orderRepo.Update(null, order);

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
  public class UserOrderController(IOrderInterface orderRepo, ICouponInterface couponRepo, IUserInterface userRepo, IPunishmentInterface punishmentRepo, ICarInterface carRepo, IPaymentInterface paymentRepo, IPayOsInterface payOs, ApplicationDBContext context, Service service) : ControllerBase
  {
    private readonly IOrderInterface _orderRepo = orderRepo;
    private readonly ICouponInterface _couponRepo = couponRepo;
    private readonly IUserInterface _userRepo = userRepo;
    private readonly IPunishmentInterface _punishmentRepo = punishmentRepo;
    private readonly ICarInterface _carRepo = carRepo;
    private readonly IPaymentInterface _paymentRepo = paymentRepo;
    private readonly IPayOsInterface _payOS = payOs;
    private readonly ApplicationDBContext _context = context;
    private readonly Service _service = service;
    private readonly double _depositPercent = 0.3;

    [HttpPost()]
    [IsUser]
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

      car.IsInUse = true;

      var carOrders = new List<CarOrder>
      {
          new() {
              CarID = req.CarID,
              StartDate = req.StartDate,
              EndDate = req.EndDate,
              Car = car
          }
      };

      user.CarRented += 1;

      double hours = req.EndDate.Subtract(req.StartDate).TotalHours;
      int cost;
      int drivingCost = 0;

      int discountPercent = 0;
      if (req.CouponID != null)
      {
        var coupon = await _couponRepo.GetCouponById((int)req.CouponID);
        discountPercent = coupon.DiscountPercent;
      }

      if (req.WithDriver)
      {
        drivingCost = 100000;
      }

      if (hours >= 24.0)
      {
        cost = car.PricePerDay * (int)Math.Ceiling(hours / 24.0) * (100 - discountPercent) / 100;
        if (req.WithDriver)
        {
          drivingCost = 100000 * (int)Math.Ceiling(hours / 24.0);
        }
      }
      else
      {
        cost = car.PricePerHour * (int)Math.Ceiling(hours) * (100 - discountPercent) / 100;
      }

      var total = cost + drivingCost;
      await using (var transaction = await _context.Database.BeginTransactionAsync())
      {
        try
        {
          var order = await _orderRepo.Create(_context, new Order
          {
            UserID = user.Id,
            CouponID = req.CouponID,
            Cost = cost,
            Deposit = (int)(total * _depositPercent),
            Message = req.Message ?? null,
            DrivingCost = drivingCost,
            CarOrders = carOrders,
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

      return Ok(total);
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

      if (order.Status != OrderStatus.PendingConfirm)
        return BadRequest();

      var car = await _carRepo.GetCarById(order.CarOrders.FirstOrDefault().CarID);
      if (car == null)
        return NotFound(ErrorMessages.CarNotFound);

      var orderCode = _service.NewOrderCode();
      CreatePaymentResult payment = null;
      await using (var transaction = await _context.Database.BeginTransactionAsync())
      {
        try
        {
          await _orderRepo.Update(_context, order);

          payment = await _payOS.CreatePayment(orderCode, car.Name, order.Deposit, 0, PaymentType.CarDeposit, order.DrivingCost);

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
          await transaction.RollbackAsync();
          Console.WriteLine($"Transaction failed: {ex.Message}");
        }
      }

      return Ok(new ConfirmOrderResponse
      {
        CheckoutURL = payment.checkoutUrl,
        OrderCode = payment.orderCode
      });
    }
    [HttpPut("{id}/cancel")]
    [IsUser]
    public async Task<IActionResult> CancelOrder([FromRoute] int id)
    {
      var order = await _orderRepo.GetOrderById(id);
      if (order == null)
        return NotFound(ErrorMessages.OrderNotFound);

      order.Status = OrderStatus.Canceled;
      var car = await _carRepo.GetCarById(order.CarOrders.FirstOrDefault().CarID);
      car.IsInUse = false;
      var user = await _userRepo.GetUserById(order.UserID);
      user.CarRented -= 1;

      await _orderRepo.Update(_context, order);
      await _userRepo.Update(_context, user);
      await _carRepo.Update(car);

      return Ok();
    }

    [HttpPut("{id}/return")]
    [IsUser]
    public async Task<IActionResult> Return([FromRoute] int id, [FromBody] UpdateOrderRequest req)
    {
      var order = await _orderRepo.GetOrderById(id);

      if (order == null)
        return NotFound(ErrorMessages.OrderNotFound);

      if (order.Status != OrderStatus.OrderSuccess)
        return BadRequest(ErrorMessages.OrderNotValid);

      order.Status = OrderStatus.PendingReturn;
      foreach (var image in req.Images)
      {
        order.Images.Add(new Image
        {
          ImageURL = image,
          Type = OrderImageType.Return
        });
      }

      await _orderRepo.Update(null, order);

      return Ok(order);
    }

    [HttpPut("{id}/pay")]
    [IsUser]
    public async Task<IActionResult> Pay([FromRoute] int id)
    {
      var order = await _orderRepo.GetOrderById(id);

      if (order == null)
        return NotFound(ErrorMessages.OrderNotFound);

      if (order.Status != OrderStatus.Returning)
        return BadRequest(ErrorMessages.OrderNotValid);

      var car = await _carRepo.GetCarById(order.CarOrders.FirstOrDefault().CarID);
      if (car == null)
        return NotFound(ErrorMessages.CarNotFound);

      var orderCode = _service.NewOrderCode();

      var punishment = await _punishmentRepo.TakePunishment(p => p.OrderID == order.Id);

      int pnm = 0;

      if (punishment != null)
      {
        pnm = punishment.Amount;
      }

      var payment = await _payOS.CreatePayment(orderCode, car.Name, order.Cost + order.DrivingCost - order.Deposit, pnm, PaymentType.TotalCost, order.DrivingCost);


      await _paymentRepo.Create(_context, new Payment
      {
        OrderCode = orderCode,
        OrderID = order.Id,
        Amount = order.Cost - order.Deposit + pnm,
        Type = PaymentType.TotalCost,
        Bin = payment.bin,
        Currency = payment.currency,
        Status = payment.status,
        CheckoutURL = payment.checkoutUrl,
        QRCode = payment.qrCode
      });

      return Ok(new ConfirmOrderResponse
      {
        CheckoutURL = payment.checkoutUrl,
        OrderCode = payment.orderCode
      });
    }

    //   [HttpPut("{id}/punishment/{punishmentId}/pay")]
    //   [IsUser]
    //   public async Task<IActionResult> PayPunishment([FromRoute] int id, int punishmentId)
    //   {
    //     var punishment = await _punishmentRepo.TakePunishment(p => p.Id == punishmentId);
    //     if (punishment == null)
    //       return BadRequest(ErrorMessages.OrderNotValid);

    //     if (punishment.IsPay)
    //       return BadRequest(ErrorMessages.PunishmentNotValid);

    //     var orderCode = _service.NewOrderCode();

    //     var payment = await _payOS.CreatePayment(orderCode, "Punishment", punishment.Amount, PaymentType.Fines);

    //     await _paymentRepo.Create(_context, new Payment
    //     {
    //       OrderCode = orderCode,
    //       OrderID = punishment.Order.Id,
    //       Amount = punishment.Amount,
    //       Type = PaymentType.Fines,
    //       Bin = payment.bin,
    //       Currency = payment.currency,
    //       Status = payment.status,
    //       CheckoutURL = payment.checkoutUrl,
    //       QRCode = payment.qrCode
    //     });

    //     return Ok(new ConfirmOrderResponse
    //     {
    //       CheckoutURL = payment.checkoutUrl,
    //       OrderCode = payment.orderCode
    //     });
    //   }
  }


}