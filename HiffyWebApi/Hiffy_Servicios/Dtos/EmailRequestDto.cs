using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiffy_Servicios.Dtos
{
    public class EmailRequestDto
    {
        public string EmailDestino { get; set; }
        public string Encabezado { get; set; }
        public string Mensaje { get; set; }
    }
}
