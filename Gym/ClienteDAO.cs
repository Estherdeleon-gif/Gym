using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace Gym
{
    public class ClienteDAO
    {
        private Conexion conexion = new Conexion();

        public bool Guardar(Cliente cliente)
        {
            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = @"INSERT INTO clientes
                  (id_usuario, nombre, apellido, cedula, telefono, correo, direccion,
                  fecha_nacimiento, sexo, foto, fecha_registro, estado)
                  VALUES
                  (@id_usuario, @nombre, @apellido, @cedula, @telefono, @correo, @direccion,
                  @fecha_nacimiento, @sexo, @foto, @fecha_registro, @estado)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id_usuario", cliente.IdUsuario);
                    cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
                    cmd.Parameters.AddWithValue("@cedula", cliente.Cedula);
                    cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@correo", cliente.Correo);
                    cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", cliente.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@sexo", cliente.Sexo);
                    cmd.Parameters.AddWithValue("@foto", cliente.Foto ?? "");
                    cmd.Parameters.AddWithValue("@fecha_registro", cliente.FechaRegistro);
                    cmd.Parameters.AddWithValue("@estado", cliente.Estado);

                    con.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = @"SELECT id_cliente, nombre, apellido, cedula, telefono,
                              correo, direccion, fecha_nacimiento, sexo, foto,
                              fecha_registro, estado
                       FROM clientes
                       ORDER BY id_cliente";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                {
                    con.Open();

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente();

                            cliente.IdCliente = reader.GetInt32(reader.GetOrdinal("id_cliente"));
                            cliente.Nombre = reader.GetString(reader.GetOrdinal("nombre"));
                            cliente.Apellido = reader.GetString(reader.GetOrdinal("apellido"));
                            cliente.Cedula = reader.GetString(reader.GetOrdinal("cedula"));
                            cliente.Telefono = reader.GetString(reader.GetOrdinal("telefono"));
                            cliente.Correo = reader.GetString(reader.GetOrdinal("correo"));
                            cliente.Direccion = reader.GetString(reader.GetOrdinal("direccion"));

                            DateOnly fechaNacimiento = reader.GetFieldValue<DateOnly>(
                                reader.GetOrdinal("fecha_nacimiento"));

                            cliente.FechaNacimiento = fechaNacimiento.ToDateTime(TimeOnly.MinValue);

                            cliente.Sexo = reader.GetString(reader.GetOrdinal("sexo"));
                            cliente.Foto = reader.GetString(reader.GetOrdinal("foto"));

                            DateOnly fechaRegistro = reader.GetFieldValue<DateOnly>(
                                reader.GetOrdinal("fecha_registro"));

                            cliente.FechaRegistro = fechaRegistro.ToDateTime(TimeOnly.MinValue);

                            cliente.Estado = reader.GetBoolean(reader.GetOrdinal("estado"));

                            lista.Add(cliente);
                        }
                    }
                }
            }

            return lista;
        }
        public Cliente ObtenerPorUsuario(int idUsuario)
        {
            Cliente cliente = null;

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = @"
                  SELECT id_cliente,
                   nombre,
                   apellido,
                   cedula,
                   telefono,
                   correo,
                   direccion,
                   fecha_nacimiento,
                   sexo,
                   foto,
                   fecha_registro,
                   estado
                   FROM clientes
                   WHERE id_usuario = @id_usuario";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id_usuario", idUsuario);

                    con.Open();

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cliente = new Cliente();

                            cliente.IdCliente =
                                reader.GetInt32(reader.GetOrdinal("id_cliente"));

                            cliente.Nombre =
                                reader.GetString(reader.GetOrdinal("nombre"));

                            cliente.Apellido =
                                reader.GetString(reader.GetOrdinal("apellido"));

                            cliente.Cedula =
                                reader.GetString(reader.GetOrdinal("cedula"));

                            cliente.Telefono =
                                reader.GetString(reader.GetOrdinal("telefono"));

                            cliente.Correo =
                                reader.GetString(reader.GetOrdinal("correo"));

                            cliente.Direccion =
                                reader.GetString(reader.GetOrdinal("direccion"));

                            DateOnly fechaNacimiento =
                                reader.GetFieldValue<DateOnly>(
                                    reader.GetOrdinal("fecha_nacimiento"));

                            cliente.FechaNacimiento =
                                fechaNacimiento.ToDateTime(TimeOnly.MinValue);

                            cliente.Sexo =
                                reader.GetString(reader.GetOrdinal("sexo"));

                            cliente.Foto =
                                reader.GetString(reader.GetOrdinal("foto"));

                            DateOnly fechaRegistro =
                                reader.GetFieldValue<DateOnly>(
                                    reader.GetOrdinal("fecha_registro"));

                            cliente.FechaRegistro =
                                fechaRegistro.ToDateTime(TimeOnly.MinValue);

                            cliente.Estado =
                                reader.GetBoolean(reader.GetOrdinal("estado"));
                        }
                    }
                }
            }

            return cliente;
        }

        public bool Actualizar(Cliente cliente)
        {
            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = @"UPDATE clientes SET
                               nombre = @nombre,
                               apellido = @apellido,
                               cedula = @cedula,
                               telefono = @telefono,
                               correo = @correo,
                               direccion = @direccion,
                               fecha_nacimiento = @fecha_nacimiento,
                               sexo = @sexo,
                               foto = @foto,
                               estado = @estado
                               WHERE id_cliente = @id_cliente";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
                    cmd.Parameters.AddWithValue("@cedula", cliente.Cedula);
                    cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@correo", cliente.Correo);
                    cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", cliente.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@sexo", cliente.Sexo);
                    cmd.Parameters.AddWithValue("@foto", cliente.Foto ?? "");
                    cmd.Parameters.AddWithValue("@estado", cliente.Estado);
                    cmd.Parameters.AddWithValue("@id_cliente", cliente.IdCliente);

                    con.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Eliminar(int idCliente)
        {
            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = "DELETE FROM clientes WHERE id_cliente = @id_cliente";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id_cliente", idCliente);

                    con.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public DataTable BuscarPorNombre(string nombre)
        {
            DataTable tabla = new DataTable();

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = @"SELECT id_cliente,
                              nombre,
                              apellido
                       FROM clientes
                       WHERE nombre ILIKE @nombre
                          OR apellido ILIKE @nombre
                       ORDER BY nombre, apellido";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@nombre", "%" + nombre + "%");

                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                    {
                        da.Fill(tabla);
                    }
                }
            }

            return tabla;
        }
    }
}