using System.ComponentModel.DataAnnotations;

namespace Final_Web_Carlos.DTOs
{
    public class MotivoUpdateDto
    {
        [Required]
        [StringLength(150)]
        public string Descripcion { get; set; } = string.Empty;
    }
}