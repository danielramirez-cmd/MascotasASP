namespace MascotasASP.Models
{
    public class ReporteModel
    {

        public int Id { get; set; }
        
        public AsignacionPaseos asignacion{ get; set; }
        public int IdAsignacion { get; set; }

        //public MascotaModel mascota { get; set; }
        //public int MascotaId { get; set; }

        public string Paseador { get; set; }
        public string Observaciones { get; set;}

        public int Duracion { get; set; }

        public string Comportamiento { get; set; }

    } // fin model
} // fin namespace 
