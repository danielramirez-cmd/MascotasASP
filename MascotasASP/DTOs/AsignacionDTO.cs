using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MascotasASP.DTOs
{
    public class AsignacionDTO
    {
        public int Id { get; set; }



        [Display(Name = "NombreMascota")]
        public string? NombreMascota { get; set; }
        public int? MascotaId { get; set; } // clave foranea de la mascota

        [Display(Name ="Fecha")]
        [Required(ErrorMessage = "Fecha de Asignacion requerida")]
        public DateTime Fecha { get; set; } // fecha de asignacion


        [Display(Name = "Hora")]
        public DateTime Hora { get; set; }
        public int? HorarioId { get; set; }

        public decimal? Costo { get; set; }

        public string ? Paseador { get; set; } // nombre del paseador 




    } // fin asignacion 
} // fin namespace 
