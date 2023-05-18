using FairyTale.API.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FairyTale.API.Models
{
    [Table("Dwarfs")]
    public class Dwarf
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
    
        public int SnowWhiteId { get; set; }

        public DwarfClass Class { get; set; }

        [InverseProperty(nameof(Models.SnowWhite.Dwarfs))]
        [ForeignKey(nameof(SnowWhiteId))]
        public SnowWhite SnowWhite { get; set; }
    }
}
