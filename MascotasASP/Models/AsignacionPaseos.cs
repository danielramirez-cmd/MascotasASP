namespace MascotasASP.Models
{
    public class AsignacionPaseos
    {
        public int Id { get; set; }
        
        public MascotaModel mascota { get; set; }
        public int? IdMascota { get; set; }

        public string? Nombre { get; set; }

        public DateTime Fecha { get; set; }

        public HorariosModel horario { get; set; }
        public int IdHorario { get; set; }
        public DateTime FechaInicio { get; set; }


        public decimal Costo { get; set; }

        public string Paseador { get; set; }

    } // fin Clase 
}  // fin namespace 
