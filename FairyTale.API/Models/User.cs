using System.ComponentModel.DataAnnotations;

namespace FairyTale.API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public SnowWhite SnowWhite { get; set; }
    }
}
