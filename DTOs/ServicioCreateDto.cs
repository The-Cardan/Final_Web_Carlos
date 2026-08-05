using System.ComponentModel.DataAnnotations;

namespace Final_Web_Carlos.DTOs
{
    public class ServicioCreateDto
    {
        [Required]
        [StringLength(120)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [Range(0.01, 1000000)]
        public decimal Precio { get; set; }
    }
}