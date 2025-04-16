using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MascotasASP.DTOs
{
    public class AsignacionDTO
    {
         public int Id { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "Fecha de Asignacion requerida")]
        public DateTime? Fecha { get; set; } // fecha de asignacion

        public decimal? Costo { get; set; }

        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }
        public int? mascotaId { get; set; } // clave foranea de la mascota

        [Display(Name = "FechaInicio")]
        public DateTime? HoraInicio { get; set; }
        public int? horarioId { get; set; }

        public string? Paseador { get; set; } // nombre del paseador 

    } // fin asignacion 
} // fin namespace 
