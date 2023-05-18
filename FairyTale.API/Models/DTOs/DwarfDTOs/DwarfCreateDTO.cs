using FairyTale.API.Models.Enums;

namespace FairyTale.API.Models.DTOs.DwarfDTOs
{
    public class DwarfCreateDTO
    {
        public string Name { get; set; }

        public DwarfClass Class { get; set; }
    }
}
