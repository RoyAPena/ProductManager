using System;

namespace ProductManagerApi.Entities.ViewModel
{
    public class DetalleProductoViewModel
    {
        public int IdDetalleProducto { get; set; }
        public int IdColor { get; set; }
        public string Color { get; set; }
        public string Capacidad { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public Byte[] Imagen { get; set; }
    }
}