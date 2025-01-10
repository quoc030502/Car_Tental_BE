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

    [HttpPut("{id}/active")]
    [IsAdmin]
    public async Task<IActionResult> ActiveUser([FromRoute] int id, [FromBody] ActiveUserRequest req)
    {
      var user = await _userRepo.ActiveUser(id, req);

      if (user == null) return NotFound(ErrorMessages.UserNotFound);

      return Ok();
    }

    [HttpDelete("{id}")]
    [IsAdmin]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      var user = await _userRepo.Delete(id);

      if (user == null) return NotFound(ErrorMessages.UserNotFound);

      return Ok();
    }

    [HttpPut("{id}")]
    [IsAdmin]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserRequest req)
    {
      var user = await _userRepo.GetUserById(id);

      if (user == null) return NotFound(ErrorMessages.UserNotFound);

      user.Username = req.Username ?? user.Username;
      user.DrivingLicense = req.DrivingLicense ?? user.DrivingLicense;
      user.Phone = req.Phone ?? user.Phone;

      await _userRepo.Update(null, user);

      return Ok();
    }
  }
  [Route("api/")]
  [ApiController]
  public class UserUserController(IUserInterface userRepo) : ControllerBase
  {
    private readonly IUserInterface _userRepo = userRepo;

    [HttpGet("me")]
    [IsUser]
    public async Task<IActionResult> GetDetail()
    {
      var user = await _userRepo.GetUserById(int.Parse(HttpContext.Items["ID"].ToString()));

      if (user == null) return NotFound(ErrorMessages.UserNotFound);

      return Ok(user);
    }

    [HttpPut("me")]
    [IsUser]
    public async Task<IActionResult> Update([FromBody] UpdateUserRequest req)
    {
      var user = await _userRepo.GetUserById(int.Parse(HttpContext.Items["ID"].ToString()));

      if (user == null) return NotFound(ErrorMessages.UserNotFound);

      user.Username = req.Username ?? user.Username;
      user.DrivingLicense = req.DrivingLicense ?? user.DrivingLicense;
      user.Phone = req.Phone ?? user.Phone;
      user.ImageURL = req.ImageURL ?? user.ImageURL;

      await _userRepo.Update(null, user);

      return Ok();
    }
  }
}
