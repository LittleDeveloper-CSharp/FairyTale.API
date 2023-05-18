using FairyTale.API.Models.DTOs;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace FairyTale.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private const string _login = "admin";
        private const string _password = "password";

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            try
            {
                if (model.Login != _login && model.Password != _password)
                {
                    return StatusCode(StatusCodes.Status403Forbidden);
                }

                var identity = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, _login)
            };

                var now = DateTime.UtcNow;
                // создаем JWT-токен
                var jwt = new JwtSecurityToken(
                        issuer: JWTOptions.ISSUER,
                audience: JWTOptions.AUDIENCE,
                notBefore: now,
                claims: identity,
                        signingCredentials: new SigningCredentials(JWTOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                var response = new
                {
                    access_token = encodedJwt,
                    username = _login
                };

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
    }
}
