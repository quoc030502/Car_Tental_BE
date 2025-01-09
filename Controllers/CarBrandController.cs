
﻿using basic_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using basic_api.Data;
using basic_api.Dtos;
using basic_api.Models;
using basic_api.Middlewares;

namespace basic_api.Controllers
{
    [Route("api/admins/car-brands")]
    [ApiController]
    public class AdminCarBrandController(ICarBrandInterface carBrandRepo) : ControllerBase
    {
        private readonly ICarBrandInterface _carBrandRepo = carBrandRepo;

        [HttpGet()]
        [IsAdmin]
        public async Task<IActionResult> GetList()
        {
            var carBrands = await _carBrandRepo.GetAll();
            return Ok(carBrands);
        }

        [HttpDelete("{id}")]
        [IsAdmin]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var carBrand = await _carBrandRepo.Delete(id);

            if (carBrand == null) return NotFound(ErrorMessages.UserNotFound);

            return Ok();
        }


        [HttpPost()]
        [IsAdmin]
        public async Task<IActionResult> Create([FromBody] CreateCarBrandRequest req)
        {
            var carBrand = await _carBrandRepo.Create(
              new CarBrand
              {
                  Brand = req.Brand,
              }
            );

            return Ok(carBrand);
        }
    }
}

﻿
