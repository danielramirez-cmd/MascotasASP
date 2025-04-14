using System.ComponentModel.DataAnnotations;

namespace MascotasASP.DTOs
{
    public class MetrosCuadradosDTO
    {
        public int Id { get; set; }

        //[Display(Name = "Categoria")]
        //[Required(ErrorMessage = "Ingresar Animal ")] // gato, perro 
        //public string? categoria { get; set; } // declaramos que debe ser en el dia o noche
        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "Cantidad de metros cuadrados requerida")]
        public decimal Metros { get; set; } // cantidad de metros cuadrados

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Descripcion de la categoria requerida")]
        public string Descripcion { get; set; } // descripcion de la categoria  

       

    } // fin clase  
} // fin namespace 
