using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiffy_Entidades.Entidades
{
    public class TareaDomestica
    {
        public int IdTarea { get; set; }
        public int IdAreaFamilia { get; set; }
        public string Descripcion { get; set; }
        public int IdTipoTarea { get; set; }
        public bool Predeterminado { get; set; }
    }
}
