using System.Data;
using Npgsql;

namespace Gym
{
    public class RolDAO
    {
        Conexion conexion = new Conexion();

        public bool Guardar(Rol rol)
        {
            bool resultado = false;

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = @"INSERT INTO roles (nombre, descripcion, estado)
                               VALUES (@nombre, @descripcion, @estado)";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@nombre", rol.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", rol.Descripcion);
                cmd.Parameters.AddWithValue("@estado", rol.Estado);
                con.Open();

                int filas = cmd.ExecuteNonQuery();

                if (filas > 0)
                {
                    resultado = true;
                }
            }

            return resultado;
        }
        public bool Actualizar(Rol rol)
        {
            bool resultado = false;

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = @"UPDATE roles
                       SET nombre = @nombre,
                           descripcion = @descripcion,
                           estado = @estado
                       WHERE id_rol = @id";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@nombre", rol.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", rol.Descripcion);
                cmd.Parameters.AddWithValue("@estado", rol.Estado);
                cmd.Parameters.AddWithValue("@id", rol.IdRol);

                int filas = cmd.ExecuteNonQuery();

                if (filas > 0)
                {
                    resultado = true;
                }
            }

            return resultado;
        }


        public DataTable Listar()
        {
            DataTable tabla = new DataTable();

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = "SELECT id_rol, nombre, descripcion, estado FROM roles ORDER BY id_rol";

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
                da.Fill(tabla);
            }

            return tabla;
        }
        public bool Eliminar(int idRol)
        {
            bool resultado = false;

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = "DELETE FROM roles WHERE id_rol = @id";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", idRol);
                con.Open();

                int filas = cmd.ExecuteNonQuery();
                

                if (filas > 0)
                {
                    resultado = true;
                }
            }

            return resultado;
        }
        public DataTable CargarComboRoles()
        {
            DataTable tabla = new DataTable();

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = "SELECT id_rol, nombre FROM roles WHERE estado = true ORDER BY nombre";

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
                da.Fill(tabla);
            }

            return tabla;
        }
    }
}
