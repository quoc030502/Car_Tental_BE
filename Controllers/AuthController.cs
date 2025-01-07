
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

