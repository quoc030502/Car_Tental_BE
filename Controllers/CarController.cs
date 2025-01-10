using basic_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using basic_api.Data;
using basic_api.Dtos;
using basic_api.Models;
using basic_api.Middlewares;

namespace basic_api.Controllers
{
  [Route("api/admins/cars")]
  [ApiController]
  public class AdminCarController(ICarInterface carRepo) : ControllerBase
  {
    private readonly ICarInterface _carRepo = carRepo;
    [HttpGet()]
    public async Task<IActionResult> GetList()
    {
      var cars = await _carRepo.GetAll();
      return Ok(cars);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail([FromRoute] int id)
    {
      var car = await _carRepo.GetCarById(id);

      if (car == null) return NotFound(ErrorMessages.CarNotFound);

      return Ok(car);
    }


    [HttpDelete("{id}")]
    [IsAdmin]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      var car = await _carRepo.Delete(id);
      if (car == null) return NotFound(ErrorMessages.CarNotFound);

      if (car.IsInUse) return BadRequest(ErrorMessages.CarIsInUse);

      return Ok();
    }

    [HttpPut("{id}")]
    [IsAdmin]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCarRequest req)
    {
      var car = await _carRepo.GetCarById(id);

      if (car == null) return NotFound(ErrorMessages.CarNotFound);

      car.Name = req.Name ?? car.Name;
      car.IsInUse = req.IsInUse ?? car.IsInUse;
      car.PricePerDay = req.PricePerDay ?? car.PricePerDay;
      car.PricePerHour = req.PricePerHour ?? car.PricePerHour;
      car.ImageURL = req.ImageURL ?? car.ImageURL;

      await _carRepo.Update(car);

      return Ok();
    }

    [HttpPost()]
    [IsAdmin]
    public async Task<IActionResult> Create([FromBody] CreateCarRequest req)
    {
      var car = await _carRepo.Create(
        new Car
        {
          Name = req.Name,
          LicensePlate = req.LicensePlate,
          IsInUse = false,
          PricePerDay = req.PricePerDay,
          PricePerHour = req.PricePerHour,
          CarTypeID = req.CarTypeID,
          CarBrandID = req.CarBrandID,
          Fuel = req.Fuel,
          ImageURL = req.ImageURL
        }
      );

      return Ok(car);
    }
  }

  [Route("api/users/cars")]
  [ApiController]
  public class UserCarController(ICarInterface carRepo, IOrderInterface orderRepo) : ControllerBase
  {
    private readonly ICarInterface _carRepo = carRepo;

    private readonly IOrderInterface _orderRepo = orderRepo;

    [HttpGet()]
    public async Task<IActionResult> UserGetList([FromQuery] UserGetListCarRequest req)
    {
      var cars = await _carRepo.GetAll();
      return Ok(cars);
    }

    [HttpGet("{id}")]
    [IsUser]
    public async Task<IActionResult> GetDetail([FromRoute] int id)
    {

      var car = await _carRepo.GetCarById(id);

      if (car == null) return NotFound(ErrorMessages.CarNotFound);

      var order = await _orderRepo.GetOrderByUserIDAndCarID(car.Id, int.Parse(HttpContext.Items["ID"].ToString()));
      var canComment = true;
      if (order == null || order.CarOrders.Count() == 0) canComment = false;

      return Ok(new
      {
        car,
        canComment
      });
    }
  }

  [Route("api/guess/cars")]
  [ApiController]
  public class GuessCarController(ICarInterface carRepo) : ControllerBase
  {
    private readonly ICarInterface _carRepo = carRepo;

    [HttpGet()]
    public async Task<IActionResult> GuessGetList([FromQuery] GuessGetListCarRequest req)
    {
      var cars = await _carRepo.GuessGetAll(req);
      return Ok(cars);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail([FromRoute] int id)
    {
      var car = await _carRepo.GetCarById(id);

      if (car == null) return NotFound(ErrorMessages.CarNotFound);

      return Ok(car);
    }
  }
}
