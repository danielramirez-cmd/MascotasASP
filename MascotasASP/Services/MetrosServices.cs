using MascotasASP.Data;
using MascotasASP.DTOs;
using MascotasASP.IServices;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace MascotasASP.Services
{
    public class MetrosServices: IMetroscuadrados
    {


        //Realizamos inyeccion de dependencias
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

       public MetrosServices(ApplicationDbContext context, IWebHostEnvironment env)
       {
            _context = context;
            _env = env;
       }

        #region "obtener Metros"
        public async Task<List<MetrosCuadradosDTO>> GetallMetros()
        {
            var metros = await _context.Set <MetrosCuadradosDTO>()
            .FromSqlRaw("EXEC usp_ObtenerMetros").ToListAsync();
            return metros;
        }

        public async Task<MetrosCuadradosDTO> GetByIdMetros(int id)
        {
            var metros = await _context.Set<MetrosCuadradosDTO>()
            .FromSqlInterpolated($"EXEC usp_ObtenerMetroId @Id = {id}")
            .AsNoTracking()
            .ToListAsync();


            var metro = metros.FirstOrDefault();

            if (metro == null)
                throw new ApplicationException($"metro con ID {id} no encontrado.");

            return metro;

        }
        #endregion

        #region "agregar metros"
        public async Task AddMetros(MetrosCuadradosDTO metrosCuadradosDTO)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync($@"
            EXEC usp_InsertarMetros 
            @Metros = {metrosCuadradosDTO.Metros}, 
            @Descripcion = {metrosCuadradosDTO.Descripcion}");
            await _context.SaveChangesAsync();
        }

        #endregion

        #region "Actualizar Metros"

        public async Task UpdateMetros(MetrosCuadradosDTO metrosCuadradosDTO)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync($@"
            EXEC usp_ActualizarMetros
            @Id = {metrosCuadradosDTO.Id},
            @Metros = {metrosCuadradosDTO.Metros}, 
            @Descripcion = {metrosCuadradosDTO.Descripcion}");

        }



        #endregion

         #region "Eliminar metros"
        public async Task DeleteMetros(int id)
        {
            var result = await _context.Database.ExecuteSqlRawAsync(
            "EXEC usp_EliminarMetro @Id",
            new SqlParameter("@Id", id));

            if (result == 0)
            {
                throw new ApplicationException("El metro no existe o ya fue eliminado.");
            }
        }

        #endregion







    } // fin clase  
} // fin namespace 
