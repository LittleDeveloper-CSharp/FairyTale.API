using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations.Schema;

namespace FairyTale.API.Models
{
    public class DwarfTransferRequest
    {
        public int Id { get; set; }

        public int? DungeonMasterSnowWhiteId { get; set; }

        [InverseProperty(nameof(SnowWhite.Requests))]
        [ForeignKey(nameof(DungeonMasterSnowWhiteId))]
        public virtual SnowWhite? DungeonMasterSnowWhite { get; set; }

        public int DwarfId { get; set; }

        [ForeignKey(nameof(DwarfId))]
        public Dwarf Dwarf { get; set; }

        [InverseProperty(nameof(SnowWhite.CreatedRequests))]
        [ForeignKey(nameof(CreatedRequestSnowWhiteId))]
        public virtual SnowWhite? CreatedRequestSnowWhite { get; set; }

        public int? CreatedRequestSnowWhiteId { get; set; }

        public bool IsClosed { get; set; }
    }
}
