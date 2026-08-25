using Npgsql;
using System;

namespace Gym
{
    public class Conexion
    {
        private readonly string cadenaConexion =
            "Host=localhost;Port=5432;Database=Gym_base_de_dato;Username=postgres;Password=12345";

        public NpgsqlConnection ObtenerConexion()
        {
            NpgsqlConnection conexion = new NpgsqlConnection(cadenaConexion);
            return conexion;
        }
    }
}