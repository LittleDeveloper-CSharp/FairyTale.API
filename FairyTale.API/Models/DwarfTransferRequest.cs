namespace FairyTale.API.Models
{
    public class DwarfTransferRequest
    {
        public int Id { get; set; }

        public int DungeonMasterSnowWhiteId { get; set; }

        public int DwarfId { get; set; }

        public int CreatedRequestSnowWhiteId { get; set; }

        public bool IsClosed { get; set; }
    }
}
