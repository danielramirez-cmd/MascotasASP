using System.ComponentModel.DataAnnotations;

namespace MascotasASP.DTOs
{
    public class HorariosDTO
    {

       public int Id { get; set; }

        [Display(Name = "Categoria")] // declaramos que debe ser en el dia o noche
        [Required(ErrorMessage ="Seleccionar Horario (Dia,Tarde,Noche)")]
        public string Categoria { get; set; }


        [Display(Name = "HoraInicio")]
        [Required(ErrorMessage = "debe tener una hora de inicio")]
        public DateTime HoraInicio { get; set; }


        [Display(Name = "HoraFin")]
        [Required(ErrorMessage = "debe tener una Hora de fin")]
        public DateTime HoraFin { get; set; }

    } // fin clase 
} // fin namespace 
