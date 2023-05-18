using FairyTale.API.Models.DTOs.DwarfDTOs;

namespace FairyTale.API.Models.DTOs.SnowWhiteDTOs
{
    public class SnowWhiteDetailsDTO
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public IEnumerable<DwarfDTO> Dwarves { get; set; }
    }
}
