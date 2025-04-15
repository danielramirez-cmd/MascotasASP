using MascotasASP.DTOs;

namespace MascotasASP.IServices
{
    public interface IAsignacion
    {

        Task<List<AsignacionDTO>> GetallAsignacion();

        Task<AsignacionDTO> GetByIdAsignacion(int id);

        

        Task UpdateAsignacion(AsignacionDTO asignacionDTO);

        Task DeleteAsignacion(int id);

    }
}
