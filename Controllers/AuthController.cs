
using basic_api.Dtos;
using basic_api.Interfaces;
using basic_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using basic_api.Services;
using basic_api.Data;
using basic_api.Constants;
using FirebaseAdmin.Auth;


namespace basic_api.Controllers
{
  [Route("api/auths")]
  [ApiController]
  public class AuthController(IUserInterface userRepo, IConfiguration configuration, Service service) : ControllerBase
  {
    private readonly IUserInterface _userRepo = userRepo;
    private readonly PasswordHasher<User> _passwordHasher = new();
    private readonly IConfiguration _configuration = configuration;
    private readonly Service _service = service;

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] LoginModel req)
    {
      var user = await _userRepo.GetUserByEmail(req.Email);

      if (user == null)
        return NotFound(ErrorMessages.UserNotFound);

      if (!user.IsVerify)
        return BadRequest(ErrorMessages.UserIsNotVerified);

      var result = _passwordHasher.VerifyHashedPassword(user, user.Password, req.Password);

      if (result == PasswordVerificationResult.Failed)
        return Unauthorized(ErrorMessages.UsernameOrPasswordIsIncorrect);


      var token = GenerateJwtToken(user);

      return Ok(new { token });
    }

    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] RegisterModel req)
    {
      var user = await _userRepo.GetUserByEmail(req.Email);
      if (user != null)
        return BadRequest(ErrorMessages.EmailAlreadyExist);

      user = new User
      {
        Username = req.Username,
        Email = req.Email,
        DrivingLicense = req.DrivingLicense,
        Phone = req.Phone,
        Role = Roles.User,
        IsRent = false,
        IsActive = false,
        IsVerify = false
      };

      user.Password = _passwordHasher.HashPassword(user, req.Password);

      var newUser = await _userRepo.Create(user);

      return Ok(newUser);
    }

    [HttpPost("generate-verifying-code")]
    public async Task<IActionResult> GenerateVerifyingCode([FromBody] GenerateVerifyingCodeRequest req)
    {
      var user = await _userRepo.GetUserByEmail(req.Email);

      if (user == null)
        return NotFound(ErrorMessages.UserNotFound);

      string otp = _service.NewOtp();

      user.VerifyCode = otp;
      user.VerifyCodeExpires = DateTime.UtcNow.AddMinutes(5);

      await _service.SendEmail(user.Email, user.Username, user.VerifyCode);

      await _userRepo.Update(null, user);

      return Ok();
    }

    [HttpPost("generate-pwd-code")]
    public async Task<IActionResult> GeneratePasswordCode([FromBody] GenerateVerifyingCodeRequest req)
    {
      var user = await _userRepo.GetUserByEmail(req.Email);

      if (user == null)
        return NotFound(ErrorMessages.UserNotFound);

      string otp = _service.NewOtp();

      user.PasswordVerifyCode = otp;
      user.PasswordVerifyCodeExpires = DateTime.UtcNow.AddMinutes(5);

      await _service.SendEmail(user.Email, user.Username, user.PasswordVerifyCode);

      await _userRepo.Update(null, user);

      return Ok();
    }

    [HttpPost("verify-code")]
    public async Task<IActionResult> VerifyCode([FromBody] VerifyCodeRequest req)
    {
      Console.WriteLine(req.Email);
      var user = await _userRepo.GetUserByEmail(req.Email);

      if (user == null)
        return NotFound(ErrorMessages.UserNotFound);

      if (user.IsVerify == true)
        return BadRequest(ErrorMessages.UserIsVerified);

      if (req.Code != user.VerifyCode)
        return BadRequest(ErrorMessages.InvalidCode);

      if (DateTime.UtcNow > user.VerifyCodeExpires)
        return BadRequest(ErrorMessages.CodeIsExpired);

      user.VerifyCode = null;
      user.VerifyCodeExpires = null;
      user.IsVerify = true;

      await _userRepo.Update(null, user);

      return Ok();
    }

    [HttpPost("pwd-verify-code")]
    public async Task<IActionResult> PasswordVerifyCode([FromBody] PasswordVerifyCodeRequest req)
    {
      Console.WriteLine(req.Email);
      var user = await _userRepo.GetUserByEmail(req.Email);

      if (user == null)
        return NotFound(ErrorMessages.UserNotFound);

      if (req.Code != user.PasswordVerifyCode)
        return BadRequest(ErrorMessages.InvalidCode);

      if (DateTime.UtcNow > user.PasswordVerifyCodeExpires)
        return BadRequest(ErrorMessages.CodeIsExpired);

      user.PasswordVerifyCode = null;
      user.PasswordVerifyCodeExpires = null;
      user.Password = _passwordHasher.HashPassword(user, req.NewPassword);

      await _userRepo.Update(null, user);

      return Ok();
    }

    [HttpPost("sign-in/google")]
    public async Task<IActionResult> LoginGoogle([FromBody] LoginGoogleRequest req)
    {
      try
      {

        if (string.IsNullOrEmpty(req.IDToken))
          return BadRequest();

        FirebaseToken decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(req.IDToken);

        UserRecord userRecord = await FirebaseAuth.DefaultInstance.GetUserByEmailAsync(decodedToken.Claims["email"].ToString());

        var user = await _userRepo.GetUserByEmail(userRecord.Email);

        user ??= await _userRepo.Create(new User
        {
          Username = userRecord.DisplayName,
          Email = userRecord.Email,
          Phone = userRecord.PhoneNumber,
          Role = Roles.User,
          GoogleUID = userRecord.Uid,
          ImageURL = userRecord.PhotoUrl,
          IsRent = false,
          IsActive = false,
          IsVerify = true
        });

        if (!user.IsVerify)
          return BadRequest(ErrorMessages.UserIsNotVerified);

        var token = GenerateJwtToken(user);

        return Ok(new { token });
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return BadRequest(ErrorMessages.InvalidLoginAttempt);
      }
    }

    private string GenerateJwtToken(User user)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(
          [
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                    new Claim("is_active", user.IsActive.ToString()),
                    new Claim("is_verify", user.IsVerify.ToString()),
                    new Claim("is_rent", user.IsRent.ToString()),
                    new Claim("driving_license", user.DrivingLicense ?? ""),
                    new Claim("image_url", user.ImageURL ?? ""),
                    new Claim("phone", user.Phone ?? ""),
                    new Claim("id", user.Id.ToString())


          ]),
        Expires = DateTime.UtcNow.AddHours(1),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };

      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }
  }
}
