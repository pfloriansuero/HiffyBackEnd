﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiffy_Entidades.Entidades
{
    public class Familia
    {
        public int IdFamilia { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public float? Altitud { get; set; }
        public float? Longitud { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
