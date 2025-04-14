using System.ComponentModel.DataAnnotations;

namespace MascotasASP.DTOs
{
    public class DueñoDTO
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Nombre Requerido")]
        public string Nombre { get; set; }

        [Display(Name ="Telefono")]
        [Required(ErrorMessage ="Telefono requerido")]
        public string Telefono { get;set; }

        [Display(Name ="Correo")]
        [Required(ErrorMessage ="Correo Requerido")]
        public string Correo { get; set; }

    } // fin DTO
} // fin namespace 
