using System.ComponentModel.DataAnnotations;

namespace Primeiro.Models
{
    public class Primary
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Howto { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}