using System;

namespace Gym
{
    public class Cliente
    {
        public int IdUsuario { get; set; }

        public int IdCliente { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Cedula { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public string Direccion { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Sexo { get; set; }

        public string Foto { get; set; }

        public DateTime FechaRegistro { get; set; }

        public bool Estado { get; set; }
    }
}
