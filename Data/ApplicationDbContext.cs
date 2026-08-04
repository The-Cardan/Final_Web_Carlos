using Final_Web_Carlos.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_Web_Carlos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Dentista> Dentistas { get; set; }
        public DbSet<Motivo> Motivos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Consultorio> Consultorios { get; set; }
        public DbSet<HorarioDentista> HorariosDentistas { get; set; }
        public DbSet<Cita> Citas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Evita que se eliminen registros relacionados automáticamente
            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Paciente)
                .WithMany(p => p.Citas)
                .HasForeignKey(c => c.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Dentista)
                .WithMany(d => d.Citas)
                .HasForeignKey(c => c.DentistaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Dentista>()
                .HasOne(d => d.Especialidad)
                .WithMany(e => e.Dentistas)
                .HasForeignKey(d => d.EspecialidadId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}