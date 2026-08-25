using System.Data;
using Npgsql;

namespace Gym
{
    public class EntrenadorDAO
    {
        private Conexion conexion = new Conexion();

        public bool Guardar(Entrenador entrenador)
        {
            bool resultado = false;

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = @"
                    INSERT INTO entrenadores
                    (nombre, apellido, telefono, correo, especialidad, horario, estado, foto)
                    VALUES
                    (@nombre, @apellido, @telefono, @correo, @especialidad, @horario, @estado, @foto)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@nombre", entrenador.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", entrenador.Apellido);
                    cmd.Parameters.AddWithValue("@telefono", entrenador.Telefono);
                    cmd.Parameters.AddWithValue("@correo", entrenador.Correo);
                    cmd.Parameters.AddWithValue("@especialidad", entrenador.Especialidad);
                    cmd.Parameters.AddWithValue("@horario", entrenador.Horario);
                    cmd.Parameters.AddWithValue("@estado", entrenador.Estado);
                    cmd.Parameters.AddWithValue("@foto", (object)entrenador.Foto ?? DBNull.Value);

                    con.Open();

                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        resultado = true;
                    }
                }
            }

            return resultado;
        }

        public bool Actualizar(Entrenador entrenador)
        {
            bool resultado = false;

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = @"
                    UPDATE entrenadores
                    SET nombre = @nombre,
                        apellido = @apellido,
                        telefono = @telefono,
                        correo = @correo,
                        especialidad = @especialidad,
                        horario = @horario,
                        estado = @estado,
                        foto = @foto
                    WHERE id_entrenador = @id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@nombre", entrenador.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", entrenador.Apellido);
                    cmd.Parameters.AddWithValue("@telefono", entrenador.Telefono);
                    cmd.Parameters.AddWithValue("@correo", entrenador.Correo);
                    cmd.Parameters.AddWithValue("@especialidad", entrenador.Especialidad);
                    cmd.Parameters.AddWithValue("@horario", entrenador.Horario);
                    cmd.Parameters.AddWithValue("@estado", entrenador.Estado);
                    cmd.Parameters.AddWithValue("@foto", (object)entrenador.Foto ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@id", entrenador.IdEntrenador);

                    con.Open();

                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        resultado = true;
                    }
                }
            }

            return resultado;
        }

        public DataTable Listar()
        {
            DataTable tabla = new DataTable();

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = @"
                    SELECT id_entrenador,
                           nombre,
                           apellido,
                           telefono,
                           correo,
                           especialidad,
                           horario,
                           estado,
                           foto
                    FROM entrenadores
                    ORDER BY id_entrenador";

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);

                da.Fill(tabla);
            }

            return tabla;
        }

        public bool Eliminar(int idEntrenador)
        {
            bool resultado = false;

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = @"
                    DELETE FROM entrenadores
                    WHERE id_entrenador = @id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", idEntrenador);

                    con.Open();

                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        resultado = true;
                    }
                }
            }

            return resultado;
        }
    }
}