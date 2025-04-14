using MascotasASP.DTOs;

namespace MascotasASP.IServices
{
    public interface IMetroscuadrados
    {
        Task AddMetros(MetrosCuadradosDTO metrosCuadradosDTO);
        Task<List<MetrosCuadradosDTO>> GetallMetros();
        Task<MetrosCuadradosDTO> GetByIdMetros(int id);
        Task UpdateMetros(MetrosCuadradosDTO metrosCuadradosDTO);
        Task DeleteMetros(int id);

    } // fin clase  
} // fin namespacce 
