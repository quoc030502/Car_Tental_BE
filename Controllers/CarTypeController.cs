using basic_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using basic_api.Data;
using basic_api.Dtos;
using basic_api.Models;
using basic_api.Middlewares;

namespace basic_api.Controllers
{
    [Route("api/admins/car-types")]
    [ApiController]
    public class AdminCarTypeController(ICarTypeInterface carTypeRepo) : ControllerBase
    {
        private readonly ICarTypeInterface _carTypeRepo = carTypeRepo;

        [HttpGet()]
        [IsAdmin]
        public async Task<IActionResult> GetList()
        {
            var carTypes = await _carTypeRepo.GetAll();
            return Ok(carTypes);
        }

        [HttpGet("{id}")]
        [IsAdmin]
        public async Task<IActionResult> GetDetail([FromRoute] int id)
        {
            var carType = await _carTypeRepo.GetCarTypeById(id);

            if (carType == null) return NotFound(ErrorMessages.UserNotFound);

            return Ok(carType);
        }


        [HttpDelete("{id}")]
        [IsAdmin]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var carType = await _carTypeRepo.Delete(id);

            if (carType == null) return NotFound(ErrorMessages.UserNotFound);

            return Ok();
        }

        [HttpPut("{id}")]
        [IsAdmin]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCarTypeRequest req)
        {
            var carType = await _carTypeRepo.GetCarTypeById(id);

            if (carType == null) return NotFound(ErrorMessages.UserNotFound);

            carType.Type = req.Type ?? carType.Type;
            carType.Detail = req.Detail ?? carType.Detail;

            await _carTypeRepo.Update(carType);

            return Ok();
        }

        [HttpPost()]
        [IsAdmin]
        public async Task<IActionResult> Create([FromBody] CreateCarTypeRequest req)
        {
            var car = await _carTypeRepo.Create(
              new CarType
              {
                  Type = req.Type,
                  Detail = req.Detail,
              }
            );

            return Ok(car);
        }
    }

    [Route("api/users/car-types")]
    [ApiController]
    public class UserCarTypeController(ICarTypeInterface carTypeRepo) : ControllerBase
    {
        private readonly ICarTypeInterface _carTypeRepo = carTypeRepo;

        [HttpGet()]
        public async Task<IActionResult> GetList()
        {
            var carTypes = await _carTypeRepo.GetAll();
            return Ok(carTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail([FromRoute] int id)
        {
            var carType = await _carTypeRepo.GetCarTypeById(id);

            if (carType == null) return NotFound(ErrorMessages.UserNotFound);

            return Ok(carType);
        }
    }

    [Route("api/guess/car-types")]
    [ApiController]
    public class GuessCarTypeController(ICarTypeInterface carTypeRepo) : ControllerBase
    {
        private readonly ICarTypeInterface _carTypeRepo = carTypeRepo;

        [HttpGet()]
        public async Task<IActionResult> GetList()
        {
            var carTypes = await _carTypeRepo.GuessGetAll();
            return Ok(carTypes);
        }
    }
}