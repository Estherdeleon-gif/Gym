using System;
using System.Collections.Generic;
using System.Text;

namespace Gym
{
    public class Mantenimiento
    {
        public int IdMantenimiento { get; set; }

        public string Equipo { get; set; }

        public DateTime Fecha { get; set; }

        public string Tipo { get; set; }

        public string Descripcion { get; set; }

        public decimal Costo { get; set; }

        public string Estado { get; set; }

        public DateTime ProximoMantenimiento { get; set; }
    }
}
