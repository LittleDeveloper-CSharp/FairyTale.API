using FairyTale.API.Data;
using FairyTale.API.Models.DTOs;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationDbContext _context;

        public AuthorizationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            try
            {
                var user = await _context.Users
                    .Include(x=> x.SnowWhite)
                    .SingleOrDefaultAsync(x=> x.Password == model.Password && x.Login == x.Login);

                if (user == null)
                {
                    return StatusCode(StatusCodes.Status403Forbidden);
                }

                var identity = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.SnowWhiteId.ToString()),
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
                    snowWhiteId = user.SnowWhite.Id
                };

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPost("registation")]
        public async Task<IActionResult> Registration(RegistrationDTO registration)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var userExists = await _context.Users.AnyAsync(x=> x.Login == registration.Login);
            if (userExists)
                return StatusCode(StatusCodes.Status409Conflict);

            _context.Users.Add(new Models.User
            {
                Login = registration.Login,
                Password = registration.Password,
                SnowWhite = new Models.SnowWhite
                {
                    FullName = registration.FullName
                }
            });

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
