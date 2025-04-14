using MascotasASP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MascotasASP.DTOs;

namespace MascotasASP.Data
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<AsignacionPaseos> AsignacionPaseos { get; set; }
        public DbSet<DueñosModel> Duenos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aquí agregas la configuración del DTO
            modelBuilder.Entity<DueñoDTO>().HasNoKey().ToView(null);
            // Aquí agregas la configuración del DTO
            modelBuilder.Entity<MetrosCuadradosDTO>().HasNoKey().ToView(null);
            modelBuilder.Entity<HorariosDTO>().HasNoKey().ToView(null);
            modelBuilder.Entity<MascotaDTO>().HasNoKey().ToView(null);
            modelBuilder.Entity<AsignacionDTO>().HasNoKey().ToView(null);
            modelBuilder.Entity<ReporteCreateDTO>().HasNoKey().ToView(null);
        }
        public DbSet<HorariosModel> Horarios { get; set; }
        public DbSet<MascotaModel> Mascotas { get; set; }
        public DbSet<MetrosCuadradosModel> MetrosCuadrados { get; set; }
        public DbSet<ReporteModel> Reportes { get; set; }

    } 
}
