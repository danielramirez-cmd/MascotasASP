using MascotasASP.DTOs;

namespace MascotasASP.IServices
{
    public interface IMascotas
    {

        Task<List<MascotaDTO>> GetallMascota();

        Task<MascotaDTO> GetByIdMascota(int id);

        Task AddMascota(MascotaDTO mascotaDTO);

        Task UpdateMascota(MascotaDTO mascotaDTO);

        Task DeleteMascota(int id);


    } // fin clase 
} // fin namespace 
