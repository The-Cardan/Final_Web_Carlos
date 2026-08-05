using System.ComponentModel.DataAnnotations;

namespace Final_Web_Carlos.DTOs
{
    public class ConsultorioUpdateDto
    {
        [Required]
        [StringLength(80)]
        public string Nombre { get; set; } = string.Empty;
    }
}