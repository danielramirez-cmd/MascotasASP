using MascotasASP.Data;
using MascotasASP.DTOs;
using MascotasASP.IServices;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MascotasASP.Services
{
    public class MascotasServices : IMascotas
    {
        //Realizamos inyeccion de dependencias
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        // constructor
        public MascotasServices(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        #region "obtener"
        public async Task<List<MascotaDTO>> GetallMascota ()
        {

            var Mascota = await _context.Set<MascotaDTO>()
            .FromSqlRaw("EXEC usp_ObtenerMascota").ToListAsync();
            return Mascota;
        }

        public async Task<MascotaDTO> GetByIdMascota(int id)
        {
            var mascotas = await _context.Set<MascotaDTO>()
            .FromSqlInterpolated($"EXEC usp_ObtenerMascotaId @Id = {id}")
            .AsNoTracking()
            .ToListAsync();


            var mascota = mascotas.FirstOrDefault();

            if (mascota == null)
                throw new ApplicationException($"Mascota con ID {id} no encontrado.");

            return mascota;

        }
        #endregion

        #region "agregar"
        public async Task AddMascota(MascotaDTO mascotaDTO)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync($@"
            usp_InsertarMascota 
            @Nombre = {mascotaDTO.Nombre}, 
            @Especie = {mascotaDTO.Especie},
            @Raza = {mascotaDTO.Raza},
            @Edad = {mascotaDTO.Edad},
            @Dueñoid = {mascotaDTO.DueñoId},
            @Metrosid = {mascotaDTO.MetrosId}");
            await _context.SaveChangesAsync();
        }

        #endregion

        #region "Actualizar "

        public async Task UpdateMascota (MascotaDTO mascotaDTO)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync($@"
            EXEC usp_ActualizarMascota
            @Id = {mascotaDTO.Id},
            @Nombre = {mascotaDTO.Nombre}, 
            @Especie = {mascotaDTO.Especie},
            @Raza = {mascotaDTO.Raza},
            @Edad = {mascotaDTO.Edad}");

        }

        #endregion

        #region "Eliminar"
        public async Task DeleteMascota(int id)
        {
            var result = await _context.Database.ExecuteSqlRawAsync(
            "EXEC usp_EliminarMascota @Id",
            new SqlParameter("@Id", id));

            if (result == 0)
            {
                throw new ApplicationException("El libro no existe o ya fue eliminado.");
            }
        }

        #endregion



    }
}
