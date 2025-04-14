using MascotasASP.DTOs;

namespace MascotasASP.IServices
{
    public interface IReporte
    {

        Task<List<ReporteCreateDTO>> GetallReportes();

    }
}
