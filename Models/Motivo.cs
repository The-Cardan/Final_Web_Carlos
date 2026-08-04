using System.ComponentModel.DataAnnotations;

namespace Final_Web_Carlos.Models
{
    public class Motivo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Descripcion { get; set; } = string.Empty;

        public ICollection<Cita>? Citas { get; set; }
    }
}