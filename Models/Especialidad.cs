using System.ComponentModel.DataAnnotations;

namespace Final_Web_Carlos.Models
{
    public class Especialidad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        // Relación: Una especialidad puede tener muchos dentistas
        public ICollection<Dentista>? Dentistas { get; set; }
    }
}
