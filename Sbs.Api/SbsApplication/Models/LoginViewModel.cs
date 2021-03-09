using System.ComponentModel.DataAnnotations;

namespace SbsApplication.Models
{
    public class LoginViewModel : ILoginViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        public string LoginName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }

    }
}
