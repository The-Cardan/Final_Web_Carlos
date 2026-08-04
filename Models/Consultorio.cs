using System.ComponentModel.DataAnnotations;

namespace Final_Web_Carlos.Models
{
    public class Consultorio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Cita>? Citas { get; set; }
    }
}