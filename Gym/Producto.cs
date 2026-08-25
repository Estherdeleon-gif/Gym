using System;
using System.Collections.Generic;
using System.Text;

namespace Gym
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdCategoria { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public string Imagen { get; set; }
        public bool Estado { get; set; }
        public int IdMarca { get; set; }
    }
}
