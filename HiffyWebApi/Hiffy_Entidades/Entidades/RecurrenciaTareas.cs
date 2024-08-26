using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiffy_Entidades.Entidades
{
    public class RecurrenciaTareas
    {
        public int IdRecurrencia { get; set; }
        public int IdTarea { get; set; }
        public int DiaSemana { get; set; }
        public string Estado { get; set; }
    }
}
