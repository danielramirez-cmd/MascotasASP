using MascotasASP.DTOs;

namespace MascotasASP.IServices
{
    public interface IDueño
    {

        Task AddDueño(DueñoDTO dueñoDTO);
        Task<DueñoDTO> GetByIdDueño(int id);
        Task<List<DueñoDTO>> GetallDueño();
        Task UpdateAsync(DueñoDTO dueñoDTO);
        Task DeleteDueño(int id);



       









    } // fin interfaz 
} // fin namespace 
