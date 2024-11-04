using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace basic_api.Services
{
    public class Service
    {
        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly int _smtpPort = 587;

        private readonly string _subject = "Your OTP to Register";

        private readonly string? _fromEmail = Environment.GetEnvironmentVariable("EMAIL");
        private readonly string? _fromPassword = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");
        public string NewOtp()
        {
            var random = new Random();
            string otp = "";

            for (int i = 0; i < 6; i++)
            {
                otp += random.Next(0, 10).ToString();
            }

            return otp;
        }

        public long NewOrderCode()
        {
            {
                var random = new Random();

                long timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

                int randomSuffix = random.Next(1000, 9999);

                string orderCodeString = timestamp.ToString() + randomSuffix.ToString();

                return long.Parse(orderCodeString);
            }
        }

        public async Task SendEmail(string toEmail, string name, string code)
        {
            if (_fromEmail == null)
                return;

            string body = File.ReadAllText("./Services/verifyingCodeEmail.html")
              .Replace("{{To}}", name)
              .Replace("{{Code}}", code);


            var smtp = new SmtpClient(_smtpServer, _smtpPort)
            {
                Credentials = new NetworkCredential(_fromEmail, _fromPassword),
                EnableSsl = true,
            };

            try
            {
                await smtp.SendMailAsync(new MailMessage(
                  from: _fromEmail,
                  to: toEmail,
                  subject: _subject,
                  body: body
                )
                {
                    IsBodyHtml = true
                });
            }
            catch (SmtpException ex)
            {
                Console.WriteLine($"SMTP Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }
    public class Jwt
    {
        public static ClaimsPrincipal? ValidateToken(string authorizationHeader, string secretKey)
        {
            if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
            {
                return null;
            }

            var token = authorizationHeader["Bearer ".Length..].Trim();
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return principal;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}