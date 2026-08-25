using Gym;
using Npgsql;
using System;
using System.Collections.Generic;

public class PagoDiarioDAO
{
    Conexion conexion = new Conexion();

   
    public bool Guardar(PagoDiario pago)
    {
        using (NpgsqlConnection con = conexion.ObtenerConexion())
        {
            string sql = @"INSERT INTO ""PagoDiario""
                           (precio_entrada, fecha, metodo_pago, concepto, estado)
                           VALUES
                           (@precio_entrada, @fecha, @metodo_pago, @concepto, @estado)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@precio_entrada", pago.PrecioEntrada);
                cmd.Parameters.AddWithValue("@fecha", pago.Fecha);
                cmd.Parameters.AddWithValue("@metodo_pago", pago.MetodoPago);
                cmd.Parameters.AddWithValue("@concepto", pago.Concepto);
                cmd.Parameters.AddWithValue("@estado", pago.Estado);

                con.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }


    public List<PagoDiario> Listar()
    {
        List<PagoDiario> lista = new List<PagoDiario>();

        using (NpgsqlConnection con = conexion.ObtenerConexion())
        {
            string sql = @"SELECT id_pago_diario,
                                  precio_entrada,
                                  fecha,
                                  metodo_pago,
                                  concepto,
                                  estado
                           FROM ""PagoDiario""
                           ORDER BY id_pago_diario";

            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                con.Open();

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PagoDiario pago = new PagoDiario();

                        pago.IdPago = reader.GetInt32(
                         reader.GetOrdinal("id_pago_diario"));

                        pago.PrecioEntrada = reader.GetDecimal(
                            reader.GetOrdinal("precio_entrada"));

                        pago.Fecha = reader.GetDateTime(
                            reader.GetOrdinal("fecha"));

                        pago.MetodoPago = reader.GetString(
                            reader.GetOrdinal("metodo_pago"));

                        pago.Concepto = reader.GetString(
                            reader.GetOrdinal("concepto"));

                        pago.Estado = reader.GetString(
                         reader.GetOrdinal("estado"));

                        lista.Add(pago);
                    }
                }
            }
        }

        return lista;
    }
    
   
    public bool Actualizar(PagoDiario pago)
    {
        using (NpgsqlConnection con = conexion.ObtenerConexion())
        {
            string sql = @"UPDATE ""PagoDiario""
                           SET precio_entrada = @precio_entrada,
                               fecha = @fecha,
                               metodo_pago = @metodo_pago,
                               concepto = @concepto,
                               estado = @estado
                           WHERE id_pago_diario = @id_pago_diario";

            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue(
                   "@id_pago_diario", pago.IdPago);

                cmd.Parameters.AddWithValue(
                    "@precio_entrada", pago.PrecioEntrada);

                cmd.Parameters.AddWithValue(
                    "@fecha", pago.Fecha);

                cmd.Parameters.AddWithValue(
                    "@metodo_pago", pago.MetodoPago);

                cmd.Parameters.AddWithValue(
                    "@concepto", pago.Concepto);

                cmd.Parameters.AddWithValue("@estado", pago.Estado);

                con.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public bool Eliminar(int idPagoDiario)
    {
        using (NpgsqlConnection con = conexion.ObtenerConexion())
        {
            string sql = @"DELETE FROM ""PagoDiario""
                           WHERE id_pago_diario = @id_pago_diario";

            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue(
                    "@id_pago_diario", idPagoDiario);

                con.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
    public List<PagoDiario> ListarPorFecha(DateTime fecha)
    {
        List<PagoDiario> lista = new List<PagoDiario>();

        using (NpgsqlConnection con = conexion.ObtenerConexion())
        {
            string sql = @"SELECT id_pago_diario,
                              precio_entrada,
                              fecha,
                              metodo_pago,
                              concepto,
                              estado
                       FROM ""PagoDiario""
                       WHERE fecha::date = @fecha
                       ORDER BY id_pago_diario";

            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@fecha", fecha.Date);

                con.Open();

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PagoDiario pago = new PagoDiario();

                        pago.IdPago = reader.GetInt32(
                            reader.GetOrdinal("id_pago_diario"));

                        pago.PrecioEntrada = reader.GetDecimal(
                            reader.GetOrdinal("precio_entrada"));

                        pago.Fecha = reader.GetDateTime(
                            reader.GetOrdinal("fecha"));

                        pago.MetodoPago = reader.GetString(
                            reader.GetOrdinal("metodo_pago"));

                        pago.Concepto = reader.GetString(
                            reader.GetOrdinal("concepto"));

                        pago.Estado = reader.GetString(
                            reader.GetOrdinal("estado"));

                        lista.Add(pago);
                    }
                }
            }
        }

        return lista;
    }

    public decimal ObtenerTotalDelDia(DateTime fecha)
    {
        using (NpgsqlConnection con = conexion.ObtenerConexion())
        {
            string sql = @"SELECT COALESCE(SUM(precio_entrada), 0)
                           FROM ""PagoDiario""
                           WHERE fecha::date = @fecha";

            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@fecha", fecha.Date);

                con.Open();

                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }
    }
}