using basic_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using basic_api.Data;
using basic_api.Middlewares;
using basic_api.Dtos;

namespace basic_api.Controllers
{
    [Route("api/admins/users")]
    [ApiController]
    public class AdminUserController(IUserInterface userRepo) : ControllerBase
    {
        private readonly IUserInterface _userRepo = userRepo;

        [HttpGet()]
        [IsAdmin]
        public async Task<IActionResult> GetList()
        {
            var users = await _userRepo.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail([FromRoute] int id)
        {
            var user = await _userRepo.GetUserById(id);

            if (user == null) return NotFound(ErrorMessages.UserNotFound);

            return Ok(user);
        }
