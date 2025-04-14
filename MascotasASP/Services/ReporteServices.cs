using MascotasASP.Data;
using MascotasASP.DTOs;
using MascotasASP.IServices;
using Microsoft.EntityFrameworkCore;

namespace MascotasASP.Services
{
    public class ReporteServices :IReporte
    {
        //Realizamos inyeccion de dependencias
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        // constructor
        public ReporteServices(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<List<ReporteCreateDTO>> GetallReportes()
        {

            var reporte = await _context.Set<ReporteCreateDTO>()
            .FromSqlRaw("sp_ObtenerPaseosConDetalle").ToListAsync();
            return reporte;
        }




    }
}
