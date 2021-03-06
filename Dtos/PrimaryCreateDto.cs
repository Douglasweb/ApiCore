using System.ComponentModel.DataAnnotations;

namespace Primeiro.Dtos
{
    public class PrimaryCreateDto
    {     
        
        [Required]
        [MaxLength(250)]
        public string Howto { get; set; }
    
        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }
        
    }
}