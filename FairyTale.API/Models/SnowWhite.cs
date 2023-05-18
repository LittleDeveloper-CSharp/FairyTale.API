using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FairyTale.API.Models
{
    public class SnowWhite
    {
        [Key]
        public int Id { get; set; }
    
        public string FullName { get; set; }

        [InverseProperty(nameof(Dwarf.SnowWhite))]
        public ICollection<Dwarf> Dwarfs { get; set; } = new HashSet<Dwarf>();

        public ICollection<DwarfTransferRequest> Requests { get; set; } = new HashSet<DwarfTransferRequest>();

        public ICollection<DwarfTransferRequest> CreatedRequests { get; set; } = new HashSet<DwarfTransferRequest>();
    }
}
