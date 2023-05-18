using FairyTale.API.Data;
using FairyTale.API.Models;
using FairyTale.API.Models.DTOs.DwarfDTOs;
using FairyTale.API.Models.DTOs.SnowWhiteDTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FairyTale.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SnowWhiteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SnowWhiteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SnowWhiteDTO>))]
        public async Task<IActionResult> Get()
        {
            var snowWhite = await _context.SnowWhites.FirstOrDefaultAsync();

            return new JsonResult(new SnowWhiteDTO
            {
                FullName = snowWhite.FullName,
                Id = snowWhite.Id
            });
        }

        [HttpGet("{id}/dwarfs")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SnowWhiteDetailsDTO))]
        public async Task<IActionResult> GetDetails(int id)
        {
            var snowWhite = await _context.SnowWhites
                .Select(x => new SnowWhiteDetailsDTO
                {
                    FullName = x.FullName,
                    Id = x.Id,
                    Dwarves = x.Dwarfs.Select(x=> new DwarfDTO
                    {
                        Id = x.Id,
                        Name = x.Name,
                    })
                })
                .SingleOrDefaultAsync(x => x.Id == id);

            return new JsonResult(snowWhite);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SnowWhiteCreateDTO model)
        {
            var snowWhite = await _context.SnowWhites.SingleOrDefaultAsync(x => x.FullName == model.FullName);
            if (snowWhite != null)
                return StatusCode(StatusCodes.Status409Conflict);

            snowWhite = new SnowWhite
            {
                FullName = model.FullName,
            };

            _context.SnowWhites.Add(snowWhite);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetDetails), snowWhite);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(SnowWhiteEditDTO model)
        {
            var snowWhite = await _context.SnowWhites.SingleOrDefaultAsync(x => x.Id == model.Id);
            if (snowWhite == null)
                return StatusCode(StatusCodes.Status404NotFound);

            var snowWhiteExists = await _context.SnowWhites.AnyAsync(x => x.Id != model.Id && x.FullName == model.FullName);

            if (snowWhiteExists)
                return StatusCode(StatusCodes.Status404NotFound);

            snowWhite.FullName = model.FullName;

            _context.SnowWhites.Update(snowWhite);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpGet("{id}/dwarfs")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DwarfDTO))]
        public async Task<IActionResult> GetDwarfs(int id)
        {
            var dwarves = await _context.Dwarfs.Where(x => x.SnowWhiteId == id)
                .Select(x => new DwarfDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Class = x.Class
                })
                .ToArrayAsync();

            return new JsonResult(dwarves);
        }
    }
}
