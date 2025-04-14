using MascotasASP.DTOs;

namespace MascotasASP.IServices
{
    public interface IHorarios
    {

        Task<List<HorariosDTO>> GetallHorarios();

        Task<HorariosDTO> GetByIdHorarios(int id);

        Task AddHorarios(HorariosDTO horariosDTO);
        Task UpdateHorarios(HorariosDTO horariosDTO);

        Task DeleteHorarios(int id);


    } // fin clase 
} // fin namespace 
