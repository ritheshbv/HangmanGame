using Sbs.Api.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Sbs.Api.Models
{
    public class LoginModel
    {
        [Required]
        public string LoginName { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class WordTypeModel
    {
        public WordType WordType { get; set; }
    }

    public class WordModel
    {
        public string Word { get; set; }
    }
}
