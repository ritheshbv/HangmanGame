using System.ComponentModel.DataAnnotations;

namespace Sbs.Api.Data.Entities
{
    public class WordDictionary
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public WordType WordType { get; set; }

        [Required]
        [MaxLength(50)]
        public string Word { get; set; }
    }
}
