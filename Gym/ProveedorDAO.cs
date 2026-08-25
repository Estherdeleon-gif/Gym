using Npgsql;
using System;
using System.Collections.Generic;

namespace Gym
{
    public class ProveedorDAO
    {
        private Conexion conexion = new Conexion();

        public bool Guardar(Proveedor proveedor)
        {
            bool resultado = false;

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = @"INSERT INTO proveedores
                               (nombre, empresa, telefono, correo, direccion, estado)
                               VALUES
                               (@nombre, @empresa, @telefono, @correo, @direccion, @estado)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@nombre", proveedor.Nombre);
                    cmd.Parameters.AddWithValue("@empresa", proveedor.Empresa);
                    cmd.Parameters.AddWithValue("@telefono", proveedor.Telefono);
                    cmd.Parameters.AddWithValue("@correo", proveedor.Correo);
                    cmd.Parameters.AddWithValue("@direccion", proveedor.Direccion);
                    cmd.Parameters.AddWithValue("@estado", proveedor.Estado);

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
        public bool Actualizar(Proveedor proveedor)
        {
            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = @"UPDATE proveedores
                       SET nombre = @nombre,
                           empresa = @empresa,
                           telefono = @telefono,
                           correo = @correo,
                           direccion = @direccion,
                           estado = @estado
                       WHERE id_proveedor = @id_proveedor";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id_proveedor", proveedor.IdProveedor);
                    cmd.Parameters.AddWithValue("@nombre", proveedor.Nombre);
                    cmd.Parameters.AddWithValue("@empresa", proveedor.Empresa);
                    cmd.Parameters.AddWithValue("@telefono", proveedor.Telefono);
                    cmd.Parameters.AddWithValue("@correo", proveedor.Correo);
                    cmd.Parameters.AddWithValue("@direccion", proveedor.Direccion);
                    cmd.Parameters.AddWithValue("@estado", proveedor.Estado);

                    con.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Eliminar(int idProveedor)
        {
            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = @"DELETE FROM proveedores
                       WHERE id_proveedor = @id_proveedor";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id_proveedor", idProveedor);

                    con.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Proveedor> Listar()
        {
            List<Proveedor> lista = new List<Proveedor>();

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = @"SELECT id_proveedor,
                                      nombre,
                                      empresa,
                                      telefono,
                                      correo,
                                      direccion,
                                      estado
                               FROM proveedores
                               ORDER BY id_proveedor";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                {
                    con.Open();

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Proveedor proveedor = new Proveedor();

                            proveedor.IdProveedor = reader.GetInt32(
                                reader.GetOrdinal("id_proveedor"));

                            proveedor.Nombre = reader.GetString(
                                reader.GetOrdinal("nombre"));

                            proveedor.Empresa = reader.GetString(
                                reader.GetOrdinal("empresa"));

                            proveedor.Telefono = reader.GetString(
                                reader.GetOrdinal("telefono"));

                            proveedor.Correo = reader.GetString(
                                reader.GetOrdinal("correo"));

                            proveedor.Direccion = reader.GetString(
                                reader.GetOrdinal("direccion"));

                            proveedor.Estado = reader.GetBoolean(
                                reader.GetOrdinal("estado"));

                            lista.Add(proveedor);
                        }
                    }
                }
            }

            return lista;
        }
    }
}