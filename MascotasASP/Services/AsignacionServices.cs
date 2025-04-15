using MascotasASP.Data;
using MascotasASP.DTOs;
using MascotasASP.IServices;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MascotasASP.Services
{
    public class AsignacionServices : IAsignacion 
    {

        //Realizamos inyeccion de dependencias
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        // constructor
        public AsignacionServices(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        #region "obtener"
        public async Task<List<AsignacionDTO>> GetallAsignacion()
        {

            var asignacion = await _context.Set<AsignacionDTO>()
            .FromSqlRaw("usp_ObtenerAsignacion").ToListAsync();
            return asignacion;
        }

        public async Task<AsignacionDTO> GetByIdAsignacion(int id)
        {
            var asignaciones = await _context.Set<AsignacionDTO>()
            .FromSqlInterpolated($"EXEC usp_ObtenerAsignacionId @Id = {id}")
            .AsNoTracking()
            .ToListAsync();


            var asignacion = asignaciones.FirstOrDefault();

            if (asignacion == null)
                throw new ApplicationException($"Asignacion con ID {id} no encontrado.");

            return asignacion;

        }
        #endregion

        #region "agregar"
        public async Task AddAsignacion(AsignacionDTO asignacionDTO)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync($@"
            usp_InsertarAsignacion
            @mascotaId = {asignacionDTO.mascotaId}, 
            @Fecha = {asignacionDTO.Fecha},
            @horarioId = {asignacionDTO.horarioId},
            @Costo = {asignacionDTO.Costo},
            @Paseador = {asignacionDTO.Paseador}");
            await _context.SaveChangesAsync();
        }

        #endregion

        #region "Actualizar "

        public async Task UpdateAsignacion(AsignacionDTO asignacionDTO)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync($@"
            EXEC usp_ActualizarMascota
            @IdMascota = {asignacionDTO.mascotaId}, 
            @Fecha = {asignacionDTO.Fecha},
            @IdHorario = {asignacionDTO.horarioId},
            @Costo = {asignacionDTO.Costo},
            @Paseador = {asignacionDTO.Paseador},
            @Horario = {asignacionDTO.FechaInicio},   
            @NombreMascota = {asignacionDTO.Nombre}");
        }
        #endregion

        #region "Eliminar"
        public async Task DeleteAsignacion(int id)
        {
            var result = await _context.Database.ExecuteSqlRawAsync(
            "EXEC usp_EliminarAsigacion @Id",
            new SqlParameter("@Id", id));

            if (result == 0)
            {
                throw new ApplicationException("La asignacion no existe o ya fue eliminado.");
            }
        }
        #endregion

    }
}
