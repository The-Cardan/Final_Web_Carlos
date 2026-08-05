using System.ComponentModel.DataAnnotations;

namespace Final_Web_Carlos.DTOs
{
    public class EspecialidadCreateDto
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;
    }
}
