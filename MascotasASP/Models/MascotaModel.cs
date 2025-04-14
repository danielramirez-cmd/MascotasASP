namespace MascotasASP.Models
{
    public class MascotaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public string Raza { get; set; }
        public int Edad { get; set; }

        public DueñosModel Dueño { get; set; } // Relación con DueñosModel
        public int DueñoId { get; set; } // Clave foránea para
        
        public MetrosCuadradosModel Metros { get; set; }
        public int MetrosId { get; set; } // Clave foránea para la relación con MetrosCuadradosModel

    } // Final MascotaModel
} // final Model
