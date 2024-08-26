using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiffy_Entidades.Entidades
{
    public class CalendarioTareas
    {
        public int IdCalendarioTareas { get; set; }
        public int IdTarea { get; set; }
        public int IdUsuario { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Prioridad { get; set; }
        public string Estado { get; set; }
    }
}
