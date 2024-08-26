using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiffy_Entidades.Entidades
{
    public class ContratoPersonal
    {
        public int IdContrato { get; set; }
        public int IdUsuario { get; set; }
        public int IdPersonal { get; set; }
        public string CodigoVerificacion { get; set; }
        public string CodigoFinalizacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }
        public int Valoracion { get; set; }
    }
}
