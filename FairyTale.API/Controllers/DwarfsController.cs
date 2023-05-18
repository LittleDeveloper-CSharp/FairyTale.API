using FairyTale.API.Data;
using FairyTale.API.Models.DTOs.DwarfDTOs;
using FairyTale.API.Models.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FairyTale.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DwarfsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DwarfsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DwarfDTO))]
        public async Task<IActionResult> Get(int id)
        {
            var dwarf = await _context.Dwarfs.FirstOrDefaultAsync(dwarf => dwarf.Id == id);
            return new JsonResult(new DwarfDTO
            {
                Id = dwarf.Id,
                Name = dwarf.Name,
                Class = dwarf.Class
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post(DwarfCreateDTO model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var snowWhiteId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultNameClaimType)?.Value);

            _context.Dwarfs.Add(new Models.Dwarf
            {
                Name = model.Name,
                SnowWhiteId = snowWhiteId,
                Class = model.Class
            });

            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var dwarf = await _context.Dwarfs.FirstOrDefaultAsync(dwarf => dwarf.Id == id);
            _context.Dwarfs.Remove(dwarf);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] DwarfEditDTO model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var dwarf = await _context.Dwarfs.FirstOrDefaultAsync(dwarf => dwarf.Id == id);
            dwarf.Name = model.Name;
            dwarf.Class = model.Class;

            _context.Dwarfs.Update(dwarf);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpGet("types")]
        public IActionResult GetTypes()
        {
            var classes = Enum.GetValues<DwarfClass>();

            return Ok(classes.Select(x => new
            {
                Id = (int)x,
                Name = x.ToString()
            }));
        }

        [HttpHead("{id}/move-to")]
        public async Task<IActionResult> CreateRequest(int id)
        {
            var dwarf = await _context.Dwarfs.FirstOrDefaultAsync(x => id == x.Id);
            var snowWhiteId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultNameClaimType)?.Value);
            if (dwarf == null)
                return NotFound();

            if (dwarf.SnowWhiteId == snowWhiteId)
                return BadRequest();

            _context.Requests.Add(new Models.DwarfTransferRequest
            {
                DungeonMasterSnowWhiteId = dwarf.SnowWhiteId,
                CreatedRequestSnowWhiteId = snowWhiteId,
                DwarfId = dwarf.Id
            });

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
