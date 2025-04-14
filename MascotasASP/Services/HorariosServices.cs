using MascotasASP.Data;
using MascotasASP.DTOs;
using MascotasASP.IServices;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MascotasASP.Services
{
    public class HorariosServices: IHorarios
    {

        //Realizamos inyeccion de dependencias
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public HorariosServices(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        #region "obtener Horarios"
        public async Task<List<HorariosDTO>> GetallHorarios()
        {

            var Horarios = await _context.Set<HorariosDTO>()
            .FromSqlRaw("EXEC usp_ObtenerHorarios").ToListAsync();
            return Horarios;
        }

        public async Task<HorariosDTO> GetByIdHorarios(int id)
        {
            var horarios = await _context.Set<HorariosDTO>()
            .FromSqlInterpolated($"EXEC usp_ObtenerHorarioId @Id = {id}")
            .AsNoTracking()
            .ToListAsync();


            var horario = horarios.FirstOrDefault();

            if (horario == null)
                throw new ApplicationException($"Horario con ID {id} no encontrado.");

            return horario;

        }
        #endregion

        #region "agregar Horario"
        public async Task AddHorarios(HorariosDTO horariosDTO)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync($@"
            usp_InsertarHorarios 
            @Categoria = {horariosDTO.Categoria}, 
            @FechaInicio = {horariosDTO.HoraInicio}, 
            @FechaFin = {horariosDTO.HoraFin}");
            await _context.SaveChangesAsync();
        }

        #endregion

        #region "Actualizar Horario"

        public async Task UpdateHorarios(HorariosDTO HorariosDTO)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync($@"
            EXEC usp_ActualizarHorarios
            @Id = {HorariosDTO.Id},
            @Categoria = {HorariosDTO.Categoria}, 
            @FechaInicio = {HorariosDTO.HoraInicio}, 
            @FechaFin = {HorariosDTO.HoraFin}");

        }

        #endregion

        #region "Eliminar Horarios"
        public async Task DeleteHorarios(int id)
        {
            var result = await _context.Database.ExecuteSqlRawAsync(
            "EXEC usp_EliminarHoario @Id",
            new SqlParameter("@Id", id));

            if (result == 0)
            {
                throw new ApplicationException("El libro no existe o ya fue eliminado.");
            }
        }

        #endregion


    } // fin clase HorariosServices
} // fin namespace MascotasASP.Services
