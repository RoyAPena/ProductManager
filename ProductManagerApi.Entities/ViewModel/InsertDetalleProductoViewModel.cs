namespace ProductManagerApi.Entities.ViewModel
{
    public class InsertDetalleProductoViewModel
    {
        public int IdProducto { get; set; }
        public int IdColor { get; set; }
        public int? IdCapacidad { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public byte[] Imagen { get; set; }
    }
}