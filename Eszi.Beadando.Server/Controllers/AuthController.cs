
using Eszi.Beadando.Server.Dtos.Auth;
using Eszi.Beadando.Server.Dtos.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Eszi.Beadando.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IOptions<JwtOptions> jwtOptions;

        public AuthController(IOptions<JwtOptions> jwtOptions)
        {
            this.jwtOptions = jwtOptions;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public ActionResult Login(LoginRequest request)
        {
            if (request.Email != "admin" || request.Password != "password")
                return Unauthorized();

            var accessToken = GenerateJwtToken(request.Email);

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTime.Now.AddMinutes(60),
                SameSite = SameSiteMode.Lax
            };

            HttpContext.Response.Cookies.Append("accessToken", accessToken, cookieOptions);

            return Ok(accessToken);
        }

        [Authorize]
        [HttpGet("cookietoken")]
        public async Task<ActionResult<string>> GetTokenFromCookie()
        {
            // A kliens minden betöltésnél megnézi, hogy van-e a sütiben érvényes token tárolva. Mivel a süti HttpOnly, csak a backend képes olvasni belőle
            Request.Cookies.TryGetValue("accessToken", out string? accessToken);

            if(string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized();
            }

            return Ok(accessToken);
        }

        [Authorize]
        [HttpPost("Logout")]
        public ActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("accessToken");

            return Ok();
        }

        private string GenerateJwtToken(string email)
        {
            var jwt = jwtOptions.Value;

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, email),
                new Claim(ClaimTypes.Role, "User")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwt.Issuer,
                audience: jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(jwt.ExpiresMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
