using Gym;
using Npgsql;
using System;
using System.Collections.Generic;

public class MantenimientoDAO
{
    Conexion conexion = new Conexion();

    // GUARDAR
    public bool Guardar(Mantenimiento mantenimiento)
    {
        using (NpgsqlConnection con = conexion.ObtenerConexion())
        {
            string sql = @"INSERT INTO ""Mantenimiento""
                           (equipo, fecha, tipo, descripcion, costo, estado, proximo_mantenimiento)
                           VALUES
                           (@equipo, @fecha, @tipo, @descripcion, @costo, @estado, @proximo_mantenimiento)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@equipo", mantenimiento.Equipo);
                cmd.Parameters.AddWithValue("@fecha", mantenimiento.Fecha);
                cmd.Parameters.AddWithValue("@tipo", mantenimiento.Tipo);
                cmd.Parameters.AddWithValue("@descripcion", mantenimiento.Descripcion);
                cmd.Parameters.AddWithValue("@costo", mantenimiento.Costo);
                cmd.Parameters.AddWithValue("@estado", mantenimiento.Estado);
                cmd.Parameters.AddWithValue(
                    "@proximo_mantenimiento",
                    mantenimiento.ProximoMantenimiento);

                con.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    // LISTAR
    public List<Mantenimiento> Listar()
    {
        List<Mantenimiento> lista = new List<Mantenimiento>();

        using (NpgsqlConnection con = conexion.ObtenerConexion())
        {
            string sql = @"SELECT id_mantenimiento,
                                  equipo,
                                  fecha,
                                  tipo,
                                  descripcion,
                                  costo,
                                  estado,
                                  proximo_mantenimiento
                           FROM ""Mantenimiento""
                           ORDER BY id_mantenimiento";

            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                con.Open();

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Mantenimiento mantenimiento = new Mantenimiento();

                        mantenimiento.IdMantenimiento = reader.GetInt32(
                            reader.GetOrdinal("id_mantenimiento"));

                        mantenimiento.Equipo = reader.GetString(
                            reader.GetOrdinal("equipo"));

                        mantenimiento.Fecha = reader.GetDateTime(
                            reader.GetOrdinal("fecha"));

                        mantenimiento.Tipo = reader.GetString(
                            reader.GetOrdinal("tipo"));

                        mantenimiento.Descripcion = reader.GetString(
                            reader.GetOrdinal("descripcion"));

                        mantenimiento.Costo = reader.GetDecimal(
                            reader.GetOrdinal("costo"));

                        mantenimiento.Estado = reader.GetString(
                            reader.GetOrdinal("estado"));

                        mantenimiento.ProximoMantenimiento = reader.GetDateTime(
                            reader.GetOrdinal("proximo_mantenimiento"));

                        lista.Add(mantenimiento);
                    }
                }
            }
        }

        return lista;
    }

    // ACTUALIZAR
    public bool Actualizar(Mantenimiento mantenimiento)
    {
        using (NpgsqlConnection con = conexion.ObtenerConexion())
        {
            string sql = @"UPDATE ""Mantenimiento""
                           SET equipo = @equipo,
                               fecha = @fecha,
                               tipo = @tipo,
                               descripcion = @descripcion,
                               costo = @costo,
                               estado = @estado,
                               proximo_mantenimiento = @proximo_mantenimiento
                           WHERE id_mantenimiento = @id_mantenimiento";

            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue(
                    "@id_mantenimiento",
                    mantenimiento.IdMantenimiento);

                cmd.Parameters.AddWithValue(
                    "@equipo",
                    mantenimiento.Equipo);

                cmd.Parameters.AddWithValue(
                    "@fecha",
                    mantenimiento.Fecha);

                cmd.Parameters.AddWithValue(
                    "@tipo",
                    mantenimiento.Tipo);

                cmd.Parameters.AddWithValue(
                    "@descripcion",
                    mantenimiento.Descripcion);

                cmd.Parameters.AddWithValue(
                    "@costo",
                    mantenimiento.Costo);

                cmd.Parameters.AddWithValue(
                    "@estado",
                    mantenimiento.Estado);

                cmd.Parameters.AddWithValue(
                    "@proximo_mantenimiento",
                    mantenimiento.ProximoMantenimiento);

                con.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    // ELIMINAR
    public bool Eliminar(int idMantenimiento)
    {
        using (NpgsqlConnection con = conexion.ObtenerConexion())
        {
            string sql = @"DELETE FROM ""Mantenimiento""
                           WHERE id_mantenimiento = @id_mantenimiento";

            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue(
                    "@id_mantenimiento",
                    idMantenimiento);

                con.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
