using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Gym
{
    public class ProductoDAO
    {
        private Conexion conexion = new Conexion();

        public bool Guardar(Producto producto)
        {
            bool resultado = false;

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = @"
                    INSERT INTO productos
                    (
                        codigo,
                        nombre,
                        descripcion,
                        id_categoria,
                        precio_compra,
                        precio_venta,
                        stock,
                        stock_minimo,
                        imagen,
                        estado,
                        id_marca
                    )
                    VALUES
                    (
                        @codigo,
                        @nombre,
                        @descripcion,
                        @id_categoria,
                        @precio_compra,
                        @precio_venta,
                        @stock,
                        @stock_minimo,
                        @imagen,
                        @estado,
                        @id_marca
                    )";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@codigo", producto.Codigo);
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@id_categoria", producto.IdCategoria);
                    cmd.Parameters.AddWithValue("@precio_compra", producto.PrecioCompra);
                    cmd.Parameters.AddWithValue("@precio_venta", producto.PrecioVenta);
                    cmd.Parameters.AddWithValue("@stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@stock_minimo", producto.StockMinimo);
                    cmd.Parameters.AddWithValue("@imagen",
                        (object)producto.Imagen ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@estado", producto.Estado);
                    cmd.Parameters.AddWithValue("@id_marca", producto.IdMarca);

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
        public bool Actualizar(Producto producto)
        {
            bool resultado = false;

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = @"
            UPDATE productos
            SET codigo = @codigo,
                nombre = @nombre,
                descripcion = @descripcion,
                id_categoria = @id_categoria,
                precio_compra = @precio_compra,
                precio_venta = @precio_venta,
                stock = @stock,
                stock_minimo = @stock_minimo,
                imagen = @imagen,
                estado = @estado,
                id_marca = @id_marca
            WHERE id_producto = @id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@codigo", producto.Codigo);
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@id_categoria", producto.IdCategoria);
                    cmd.Parameters.AddWithValue("@precio_compra", producto.PrecioCompra);
                    cmd.Parameters.AddWithValue("@precio_venta", producto.PrecioVenta);
                    cmd.Parameters.AddWithValue("@stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@stock_minimo", producto.StockMinimo);
                    cmd.Parameters.AddWithValue("@imagen",
                        (object)producto.Imagen ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@estado", producto.Estado);
                    cmd.Parameters.AddWithValue("@id_marca", producto.IdMarca);
                    cmd.Parameters.AddWithValue("@id", producto.IdProducto);

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
        public bool Eliminar(int idProducto)
        {
            bool resultado = false;

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = @"
            DELETE FROM productos
            WHERE id_producto = @id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", idProducto);

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
                    SELECT
                        p.id_producto,
                        p.codigo,
                        p.nombre,
                        p.descripcion,
                        p.id_categoria,
                        c.nombre AS categoria,
                        p.precio_compra,
                        p.precio_venta,
                        p.stock,
                        p.stock_minimo,
                        p.imagen,
                        p.estado,
                        p.id_marca,
                        m.nombre AS marca
                    FROM productos p
                    LEFT JOIN categoriasproductos c
                        ON p.id_categoria = c.id_categoria
                    LEFT JOIN marcas m
                        ON p.id_marca = m.id_marca
                    ORDER BY p.id_producto";

                NpgsqlDataAdapter da =
                    new NpgsqlDataAdapter(sql, con);

                da.Fill(tabla);
            }

            return tabla;

        }
        public DataTable Buscar(string texto)
        {
            DataTable tabla = new DataTable();

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = @"
            SELECT
                p.id_producto,
                p.codigo,
                p.nombre,
                p.descripcion,
                p.id_categoria,
                c.nombre AS categoria,
                p.precio_compra,
                p.precio_venta,
                p.stock,
                p.stock_minimo,
                p.imagen,
                p.estado,
                p.id_marca,
                m.nombre AS marca
            FROM productos p
            LEFT JOIN categoriasproductos c
                ON p.id_categoria = c.id_categoria
            LEFT JOIN marcas m
                ON p.id_marca = m.id_marca
            WHERE LOWER(p.codigo) LIKE LOWER(@texto)
               OR LOWER(p.nombre) LIKE LOWER(@texto)
            ORDER BY p.id_producto";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@texto", "%" + texto + "%");

                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);

                    da.Fill(tabla);
                }
            }

            return tabla;
        }

        public DataTable CargarCategorias()
        {
            DataTable tabla = new DataTable();

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = @"
            SELECT id_categoria, nombre
            FROM categoriasproductos
            WHERE estado = true
            ORDER BY nombre";

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);

                da.Fill(tabla);
            }

            return tabla;
        }

        public DataTable CargarMarcas()
        {
            DataTable tabla = new DataTable();

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = @"
            SELECT id_marca, nombre
            FROM marcas
            WHERE estado = true
            ORDER BY nombre";

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);

                da.Fill(tabla);
            }

            return tabla;
        }
        public DataTable BuscarParaCliente(string texto)
        {
            DataTable tabla = new DataTable();

            using (NpgsqlConnection con = conexion.ObtenerConexion())
            {
                string sql = @"
            SELECT
                p.nombre,
                p.descripcion,
                p.precio_venta,
                CASE
                    WHEN p.stock > 0 THEN 'Disponible'
                    ELSE 'Agotado'
                END AS disponibilidad
            FROM productos p
            WHERE p.estado = true
              AND (
                    LOWER(p.nombre) LIKE LOWER(@texto)
                    OR LOWER(p.codigo) LIKE LOWER(@texto)
                  )
            ORDER BY p.nombre";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@texto", "%" + texto + "%");

                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);

                    da.Fill(tabla);
                }
            }

            return tabla;
        }

    }
}
