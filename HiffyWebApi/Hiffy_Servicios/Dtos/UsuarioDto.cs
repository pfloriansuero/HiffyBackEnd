using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiffy_Servicios.Dtos
{
    public class UsuarioDto
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int IdRol { get; set; }
        public int IdFamilia { get; set; }
    }
}
