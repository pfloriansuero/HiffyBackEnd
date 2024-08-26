using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiffy_Entidades.Entidades
{
    public class DispositivoFamilia
    {
        public int IdDispositivoFamilia { get; set; }
        public int IdDispositivo { get; set; }
        public int IdAreaFamilia { get; set; }
        public string Estado { get; set; }
    }
}
