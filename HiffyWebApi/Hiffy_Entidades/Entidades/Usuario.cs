using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiffy_Entidades.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public DateTime FechaNacimiento { get; set;} 
        public string Estado { get; set; }
        public int IdRol { get; set; }
        public int IdFamilia { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Valoracion { get; set; }
        public string? CodigoVerificacion { get; set; }
        public DateTime? FechaLimiteCodigo { get; set; }
    }
}
