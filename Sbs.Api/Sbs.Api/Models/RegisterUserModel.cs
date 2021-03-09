using System.ComponentModel.DataAnnotations;

namespace Sbs.Api.Models
{
    public class RegisterUserModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string LoginName { get; set; }
    }
}
