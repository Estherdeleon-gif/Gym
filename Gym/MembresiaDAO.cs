using Gym;
using Npgsql;
using System;
using System.Collections.Generic;

public class MembresiaDAO
{
    Conexion conexion = new Conexion();

  
    public bool Guardar(Membresia membresia)
    {
        using (NpgsqlConnection con = conexion.ObtenerConexion())
        {
            string sql = @"INSERT INTO ""Membresia""
                           (id_cliente, tipo, fecha_inicio, fecha_fin, precio, estado)
                           VALUES
                           (@id_cliente, @tipo, @fecha_inicio, @fecha_fin, @precio, @estado)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id_cliente", membresia.IdCliente);
                cmd.Parameters.AddWithValue("@tipo", membresia.Tipo);
                cmd.Parameters.AddWithValue("@fecha_inicio", membresia.FechaInicio);
                cmd.Parameters.AddWithValue("@fecha_fin", membresia.FechadeExpiracion);
                cmd.Parameters.AddWithValue("@precio", membresia.CostodeMembresia);
                cmd.Parameters.AddWithValue("@estado", membresia.Estado);

                con.Open(); 

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    // LISTAR
    public List<Membresia> Listar()
    {
        List<Membresia> lista = new List<Membresia>();

        using (NpgsqlConnection con = conexion.ObtenerConexion())
        {
            string sql = @"SELECT id_membresia,
                                  id_cliente,
                                  tipo,
                                  fecha_inicio,
                                  fecha_fin,
                                  precio,
                                  estado
                           FROM ""Membresia""
                           ORDER BY id_membresia";

            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                con.Open();

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Membresia membresia = new Membresia();

                        membresia.IdMembresia = reader.GetInt32(
                            reader.GetOrdinal("id_membresia"));

                        membresia.IdCliente = reader.GetInt32(
                            reader.GetOrdinal("id_cliente"));

                        membresia.Tipo = reader.GetString(
                            reader.GetOrdinal("tipo"));

                        membresia.FechaInicio = reader.GetDateTime(
                            reader.GetOrdinal("fecha_inicio"));

                        membresia.FechadeExpiracion = reader.GetDateTime(
                            reader.GetOrdinal("fecha_fin"));

                        membresia.CostodeMembresia = reader.GetDecimal(
                            reader.GetOrdinal("precio"));

                        membresia.Estado = reader.GetBoolean(
                            reader.GetOrdinal("estado"));

                        lista.Add(membresia);
                    }
                }
            }
        }

        return lista;
    }

    public bool Actualizar(Membresia membresia)
    {
        using (NpgsqlConnection con = conexion.ObtenerConexion())
        {
            string sql = @"UPDATE ""Membresia""
                           SET id_cliente = @id_cliente,
                               tipo = @tipo,
                               fecha_inicio = @fecha_inicio,
                               fecha_fin = @fecha_fin,
                               precio = @precio,
                               estado = @estado
                           WHERE id_membresia = @id_membresia";

            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id_membresia", membresia.IdMembresia);
                cmd.Parameters.AddWithValue("@id_cliente", membresia.IdCliente);
                cmd.Parameters.AddWithValue("@tipo", membresia.Tipo);
                cmd.Parameters.AddWithValue("@fecha_inicio", membresia.FechaInicio);
                cmd.Parameters.AddWithValue("@fecha_fin", membresia.FechadeExpiracion);
                cmd.Parameters.AddWithValue("@precio", membresia.CostodeMembresia);
                cmd.Parameters.AddWithValue("@estado", membresia.Estado);

                con.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }


    public bool Eliminar(int idMembresia)
    {
        using (NpgsqlConnection con = conexion.ObtenerConexion())
        {
            string sql = @"DELETE FROM ""Membresia"" WHERE id_membresia = @id_membresia";

            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id_membresia", idMembresia);

                con.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
} 
