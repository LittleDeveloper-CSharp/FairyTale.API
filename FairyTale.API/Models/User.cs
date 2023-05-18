using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FairyTale.API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public int SnowWhiteId { get; set; }

        [ForeignKey(nameof(SnowWhiteId))]
        public virtual SnowWhite SnowWhite { get; set; }
    }
}
