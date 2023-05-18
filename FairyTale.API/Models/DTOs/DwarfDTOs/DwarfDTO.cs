using FairyTale.API.Models.Enums;

namespace FairyTale.API.Models.DTOs.DwarfDTOs
{
    public class DwarfDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DwarfClass Class { get; set; }
    }
}
