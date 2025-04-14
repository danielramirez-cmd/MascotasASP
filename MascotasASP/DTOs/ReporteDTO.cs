using MascotasASP.Models;

namespace MascotasASP.DTOs
{
    public class ReporteDTO
    {

        public int Id { get; set; }
       
        public MascotaModel Mascotas { get; set; } // objeto de la mascota
        public int? MascotaId { get; set; } // clave foranea de la mascota
        public DateTime Fecha { get; set; } // fecha de asignacion

        public string Mascota { get; set; } // nombre de la mascota

        public HorariosModel Horario { get; set; } // objeto de la hora
        public int? HorarioId { get; set; }
        public double? Costo { get; set; }
        public string? Paseador { get; set; } // nombre del paseador

        public string Observaciones { get; set; } // observaciones del paseador
        public AsignacionPaseos Asignacion { get; set; } // objeto de la asignacion
        public int? IdAsignacion { get; set; } // clave foranea de la asignacion




        DueñoDTO dueño = new DueñoDTO(); // objeto del dueño
        public string NombreDueno { get; set; }







    } // fin clase
} // fin namespace
