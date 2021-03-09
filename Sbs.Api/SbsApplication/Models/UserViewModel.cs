using System.ComponentModel.DataAnnotations;

namespace SbsApplication.Models
{
    public class UserViewModel : IUserViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string LoginName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }

    }

}
