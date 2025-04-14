using MascotasASP.Data;
using MascotasASP.DTOs;
using MascotasASP.IServices;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MascotasASP.Services
{
    public class DueñoServices :IDueño
    {

        //Realizamos inyeccion de dependencias
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public DueñoServices(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        #region "agregar dueño"
        public async Task AddDueño(DueñoDTO dueñoDTO)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync($@"
            EXEC usp_InsertarDueño 
            @Nombre = {dueñoDTO.Nombre}, 
            @Telefono = {dueñoDTO.Telefono}, 
            @Correo = {dueñoDTO.Correo}");
            await _context.SaveChangesAsync();
        }

        #endregion

        #region "obtener dueños"
        public async Task<List<DueñoDTO>> GetallDueño() {

            var dueños = await _context.Set<DueñoDTO>()
            .FromSqlRaw("EXEC usp_ObtenerDueño").ToListAsync();
            return dueños;
        }

        public async Task<DueñoDTO> GetByIdDueño(int id)
        {
            var dueños = await _context.Set<DueñoDTO>()
            .FromSqlInterpolated($"EXEC usp_ObtenerDueñoId @Id = {id}")
            .AsNoTracking()
            .ToListAsync();


            var dueño = dueños.FirstOrDefault();

            if (dueño == null)
                throw new ApplicationException($"dueño con ID {id} no encontrado.");

            return dueño;

        }



        #endregion

        #region "Actualizar Dueño"

        public async Task UpdateAsync(DueñoDTO dueñoDTO)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync($@"
            EXEC usp_ActualizarDueño
            @Id = {dueñoDTO.Id},
            @Nombre = {dueñoDTO.Nombre}, 
            @Telefono = {dueñoDTO.Telefono}, 
            @Correo = {dueñoDTO.Correo}");

        }

        #endregion 

        #region "Eliminar dueño"
        public async Task DeleteDueño(int id)
        {
            var result = await _context.Database.ExecuteSqlRawAsync(
            "EXEC usp_EliminarDueño @Id",
            new SqlParameter("@Id", id));

            if (result == 0)
            {
                throw new ApplicationException("El libro no existe o ya fue eliminado.");
            }
        }

        #endregion





    } // fin class services 
} // fin namespace 
