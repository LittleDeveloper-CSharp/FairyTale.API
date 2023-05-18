using System.ComponentModel.DataAnnotations;

namespace FairyTale.API.Models.DTOs
{
    public class RegistrationDTO
    {
        [Required]
        public string Login { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        public string FullName { get; set; }
    }
}
