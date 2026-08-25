using System.Data;
using Npgsql;

namespace Gym
{
    public class UsuarioDAO
    {
        Conexion conexion = new Conexion();

        public int Guardar(Usuario usuario)
        {
            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = @"INSERT INTO usuarios
                       (nombre, usuario, contrasena, id_rol, estado)
                       VALUES
                       (@nombre, @usuario, @contrasena, @id_rol, @estado)
                       RETURNING id_usuario";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@usuario", usuario.UsuarioLogin);
                    cmd.Parameters.AddWithValue("@contrasena", usuario.Contrasena);
                    cmd.Parameters.AddWithValue("@id_rol", usuario.IdRol);
                    cmd.Parameters.AddWithValue("@estado", true);
                    con.Open();

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public DataTable Listar()
        {
            DataTable tabla = new DataTable();

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = @"SELECT id_usuario,
                                      nombre,
                                      usuario,
                                      id_rol,
                                      estado
                               FROM usuarios
                               ORDER BY id_usuario";

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
                da.Fill(tabla);
            }

            return tabla;
        }
        public bool Actualizar(Usuario usuario)
        {
            bool resultado = false;

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = @"UPDATE usuarios
                       SET nombre = @nombre,
                           usuario = @usuario,
                           contrasena = @contrasena,
                           id_rol = @id_rol,
                           estado = @estado
                       WHERE id_usuario = @id_usuario";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@usuario", usuario.UsuarioLogin);
                cmd.Parameters.AddWithValue("@contrasena", usuario.Contrasena);
                cmd.Parameters.AddWithValue("@id_rol", usuario.IdRol);
                cmd.Parameters.AddWithValue("@estado", usuario.Estado);
                cmd.Parameters.AddWithValue("@id_usuario", usuario.IdUsuario);

                con.Open();

                int filas = cmd.ExecuteNonQuery();

                if (filas > 0)
                {
                    resultado = true;
                }
            }

            return resultado;
        }
        public bool Eliminar(int idUsuario)
        {
            bool resultado = false;

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = "DELETE FROM usuarios WHERE id_usuario = @id_usuario";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                con.Open();

                int filas = cmd.ExecuteNonQuery();

                if (filas > 0)
                {
                    resultado = true;
                }
            }

            return resultado;
        }

    } 
}
