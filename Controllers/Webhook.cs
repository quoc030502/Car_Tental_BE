
using basic_api.Interfaces;
using basic_api.Models;
using Microsoft.AspNetCore.Mvc;
using basic_api.Services;
using basic_api.Data;
using basic_api.Dtos;
using basic_api.Middlewares;
using Microsoft.OpenApi.Any;
using Net.payOS.Types;
using basic_api.Constants;


namespace basic_api.Controllers
{
  [Route("api")]
  [ApiController]
  public class WebhookController(ICarInterface carRepo, IUserInterface userRepo, IPaymentInterface paymentRepo, IPunishmentInterface punishmentRepo, IConfiguration configuration, Service service) : ControllerBase
  {
    private readonly ICarInterface _carRepo = carRepo;
    private readonly IUserInterface _userRepo = userRepo;
    private readonly IPaymentInterface _paymentRepo = paymentRepo;
    private readonly IPunishmentInterface _punishmentRepoRepo = punishmentRepo;
    private readonly Service _service = service;

    [HttpPost("webhook")]
    public async Task<IActionResult> Webhook([FromBody] WebhookType req)
    {
      var payment = await _paymentRepo.TakePayment(p => p.OrderCode == req.data.orderCode);
      if (payment == null)
      {
        return NotFound();
      }

      if (!req.success)
      {
        payment.Status = PaymentStatus.FAILED;
        await _paymentRepo.Update(payment);
        return Ok();
      }

      payment.Status = PaymentStatus.SUCCESS;

      switch (req.data.description)
      {
        case PaymentType.CarDeposit:
          payment.Order.IsDeposit = true;
          payment.Order.Status = OrderStatus.OrderSuccess;

          await _paymentRepo.Update(payment);

          break;

        case PaymentType.TotalCost:

          payment.Order.IsPay = true;
          payment.Order.Status = OrderStatus.Success;

          var user = await _userRepo.GetUserById(payment.Order.UserID);

          user.CarRented = payment.Order.User.CarRented - 1;

          var car = await _carRepo.GetCarById(payment.Order.CarOrders.FirstOrDefault().CarID);
          car.IsInUse = false;

          Console.WriteLine(car);
          await _carRepo.Update(car);

          Console.WriteLine("req.data.descriptionxxxxxxxxxxxxxxx");
          var pnm = await _punishmentRepoRepo.TakePunishment(p => payment.OrderID == payment.OrderID);
          if (pnm == null)
          {
            await _paymentRepo.Update(payment);
            break;
          }

          pnm.IsPay = true;
          payment.Order.IsPunish = false;
          user.IsLock = false;
          await _paymentRepo.Update(payment);
          await _punishmentRepoRepo.Update(pnm);
          await _userRepo.Update(null, user);
          break;
        default:
          break;
      }

      return Ok();
    }
  }
}