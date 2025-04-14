using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

namespace MascotasASP.DTOs
{
    public class MascotaDTO
    {
        public int Id { get; set; }
        [Display(Name = "NombreMascota")]
        [Required(ErrorMessage = "Nombre de la Mascota requerido")]
        public string Nombre { get; set; }   


        [Display(Name = "Especie")]
        [Required(ErrorMessage ="Especie de mascota Requerido")] 
        public string Especie { get; set; }

        [Display(Name = "Raza")]
        [Required(ErrorMessage = "Raza de mascota Requerido")]
        public string Raza { get; set; }


        [Display(Name = "Edad")]
        [Required(ErrorMessage = "Raza de mascota Requerido")]
        public int Edad { get; set; }


        [Display(Name = "Dueño")]
        public string? Dueño { get; set; }

        [Display(Name = "Metros")]
        public decimal? Metros { get; set; }
        public int? DueñoId { get; set; }
        public int? MetrosId { get; set; }

    } // fin mascota DTO
} // fin namespace 
