using Npgsql;
using System;
using System.Collections.Generic;

namespace Gym
{
    public class PermisosDAO
    {
        private Conexion conexion = new Conexion();

        // Guardar y actualizar un permiso
        public bool Guardar(Permiso permiso)
        {
            bool resultado = false;

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                con.Open();

                string sql = @"
                    INSERT INTO permisos
                    (id_rol, modulo, ver, crear, editar, eliminar)
                    VALUES
                    (@id_rol, @modulo, @ver, @crear, @editar, @eliminar)
                    ON CONFLICT (id_rol, modulo)
                    DO UPDATE SET
                        ver = EXCLUDED.ver,
                        crear = EXCLUDED.crear,
                        editar = EXCLUDED.editar,
                        eliminar = EXCLUDED.eliminar;";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id_rol", permiso.IdRol);
                    cmd.Parameters.AddWithValue("@modulo", permiso.Modulo);
                    cmd.Parameters.AddWithValue("@ver", permiso.Ver);
                    cmd.Parameters.AddWithValue("@crear", permiso.Crear);
                    cmd.Parameters.AddWithValue("@editar", permiso.Editar);
                    cmd.Parameters.AddWithValue("@eliminar", permiso.Eliminar);

                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        resultado = true;
                    }
                }
            }

            return resultado;
        }


        
        public List<Permiso> ObtenerPorRol(int idRol)
        {
            List<Permiso> lista = new List<Permiso>();

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                con.Open();

                string sql = @"
                    SELECT id_permiso, id_rol, modulo,
                           ver, crear, editar, eliminar
                    FROM permisos
                    WHERE id_rol = @id_rol
                    ORDER BY modulo;";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id_rol", idRol);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Permiso permiso = new Permiso();

                            permiso.IdPermiso = Convert.ToInt32(reader["id_permiso"]);
                            permiso.IdRol = Convert.ToInt32(reader["id_rol"]);
                            permiso.Modulo = reader["modulo"].ToString();
                            permiso.Ver = Convert.ToBoolean(reader["ver"]);
                            permiso.Crear = Convert.ToBoolean(reader["crear"]);
                            permiso.Editar = Convert.ToBoolean(reader["editar"]);
                            permiso.Eliminar = Convert.ToBoolean(reader["eliminar"]);

                            lista.Add(permiso);
                        }
                    }
                }
            }

            return lista;
        }
    }
}
