using System.ComponentModel.DataAnnotations;

namespace Final_Web_Carlos.Models
{
    public class Servicio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string Nombre { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        public decimal Precio { get; set; }

        public ICollection<Cita>? Citas { get; set; }
    }
}